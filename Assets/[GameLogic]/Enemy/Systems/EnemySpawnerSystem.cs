using System.Collections.Generic;
using DesperateDevs.Utils;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _GameLogic_.Enemy
{
    public class EnemySpawnerSystem : ReactiveSystem<GameEntity>,IInitializeSystem
    {
        private readonly GameContext _contextsGame;
        private GameEntity _spawnerEntity;
        public static ObjectPool<EnemyView> Pool;
        private EnemyView _prefab;

        public EnemySpawnerSystem(Contexts contexts) : base(contexts.game)
        {
            _contextsGame = contexts.game;
        }

        public void Initialize()
        {
            
            _spawnerEntity = _contextsGame.CreateEntity();
            _spawnerEntity.isEnemySpawner = true;
            _spawnerEntity.AddCooldown(2f);
            _spawnerEntity.AddEnemyAmount(10);
            _spawnerEntity.AddTimerAmount(_spawnerEntity.cooldown.value);
            var spawnerView = UnityEngine.Object.FindObjectOfType<SpawnerView>();
            spawnerView.Link(_spawnerEntity);
            _prefab = spawnerView.EnemyViewPrefab;
            Pool = new ObjectPool<EnemyView>(InstantiateEnemy,UnlinkEnemy);
            for (int i = 0; i < 6; i++)
            {
                Pool.Push(InstantiateEnemy());
            }
        }

        private void UnlinkEnemy(EnemyView obj)
        {
            obj.transform.gameObject.SetActive(false);
            if (obj.GameEntity != null)
            {
                obj.GameEntity.RemoveAllComponents();
                obj.transform.gameObject.Unlink();
                obj.GameEntity = null;
            }
        }

        private EnemyView InstantiateEnemy()
        {
            var enemyView = UnityEngine.Object.Instantiate(_prefab);
            _prefab.transform.position = _spawnerEntity.transform.value.position;
            return enemyView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SpawnRequest.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return _spawnerEntity.enemyAmount.value > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var enemyView = Pool.Get();
            Transform transform;
            (transform = enemyView.transform).gameObject.SetActive(true);
            transform.position = _spawnerEntity.transform.value.position;
            _spawnerEntity.ReplaceEnemyAmount(_spawnerEntity.enemyAmount.value - 1);
            var enemyEntity = _contextsGame.CreateEntity();
            enemyView.Link(enemyEntity);
            enemyEntity.ReplaceAttackDamage(4f);
            enemyEntity.ReplaceHealth(10);
            enemyEntity.ReplaceReward(50);
            enemyEntity.ReplaceNMAgentDestination(_contextsGame.castleEntity.transform.value.position);
        }
    }
}