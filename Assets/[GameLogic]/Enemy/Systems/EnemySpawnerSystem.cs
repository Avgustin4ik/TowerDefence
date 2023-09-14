using System.Collections.Generic;
using _GameLogic_.Data;
using DesperateDevs.Utils;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _GameLogic_.Enemy
{
    public class EnemySpawnerSystem : ReactiveSystem<GameEntity>,IInitializeSystem
    {
        public static ObjectPool<EnemyView> Pool;
        private readonly GameContext _contextsGame;
        private GameEntity _spawnerEntity;
        private EnemyView _prefab;
        private EnemyConfig _enemyConfig;
        private const int PoolLenght = 20;

        public EnemySpawnerSystem(Contexts contexts, EnemyConfig enemyConfig) : base(contexts.game)
        {
            _contextsGame = contexts.game;
            _enemyConfig = enemyConfig;
        }

        public void Initialize()
        {
            
            _spawnerEntity = _contextsGame.CreateEntity();
            _spawnerEntity.isEnemySpawner = true;
            _spawnerEntity.AddCooldown(_enemyConfig.EnemySpawnDelay);
            var curWave = 1;
            _spawnerEntity.AddEnemyAmount(UnityEngine.Random.Range(curWave, curWave + _enemyConfig.MaxAdditionalEnemyCount));
            _spawnerEntity.AddTimerAmount(_spawnerEntity.cooldown.value);
            var spawnerView = UnityEngine.Object.FindObjectOfType<SpawnerView>();
            spawnerView.Link(_spawnerEntity);
            _prefab = spawnerView.EnemyViewPrefab;
            Pool = new ObjectPool<EnemyView>(InstantiateEnemy,UnlinkEnemy);
            for (int i = 0; i < PoolLenght; i++)
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
            var enemyView = UnityEngine.Object.Instantiate(_prefab, _spawnerEntity.spawnPoint.value, Quaternion.identity);
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
            enemyView.transform.gameObject.SetActive(true);
            _spawnerEntity.ReplaceEnemyAmount(_spawnerEntity.enemyAmount.value - 1);
            var enemyEntity = _contextsGame.CreateEntity();
            enemyView.Link(enemyEntity);
            enemyEntity.ReplaceAttackDamage(_enemyConfig.DefaultEnemyDamage);
            enemyEntity.ReplaceHealth(_enemyConfig.DefaultEnemyHp);
            enemyEntity.ReplaceReward(_enemyConfig.DefaultEnemyReward);
            enemyEntity.ReplaceNMAgentDestination(_contextsGame.castleEntity.transform.value.position);
            enemyEntity.transform.value.position = _spawnerEntity.spawnPoint.value;
        }
    }
}