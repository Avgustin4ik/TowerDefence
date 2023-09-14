using _GameLogic_.Data;
using Entitas;
using UnityEngine;

namespace _GameLogic_.Enemy
{
    public class EnemySystems : Feature
    {
        private EnemyConfig _enemyConfig;

        public EnemySystems(Contexts contexts)
        {
            _enemyConfig = Resources.Load<EnemyConfig>("Balance/EnemyConfig");
            Add(new EnemySpawnerSystem(contexts, _enemyConfig));
            Add(new EnemySpawnerRequestSystem(contexts));
            Add(new NavMeshMovingSystem(contexts));
            Add(new EnemyAttackSystem(contexts));
            Add(new EnemyDetectTargetSystem(contexts));
            Add(new EnemyDeathSystem(contexts));
            Add(new AddNewEnemySystem(contexts, _enemyConfig));
            // Add(new EnemySpawnSystem(contexts));
            Add(new EnemyTestSystem(contexts.game));
        }
    }

    public class EnemyTestSystem : IInitializeSystem
    {
        private readonly GameContext _contextsGame;

        public EnemyTestSystem(GameContext contextsGame)
        {
            _contextsGame = contextsGame;
        }

        public void Initialize()
        {
            
            // var enemyView = UnityEngine.Object.FindObjectOfType<EnemyView>();
            // var pointView = UnityEngine.Object.FindObjectOfType<CastleView>();
            // var enemyEntity = _contextsGame.CreateEntity();
            // enemyView.Link(enemyEntity);
            // enemyEntity.AddAttackDamage(4f);
            // enemyEntity.AddHealth(10);
            // enemyEntity.AddReward(50);
            // enemyEntity.AddNMAgentDestination(pointView.transform.position);
        }
        
        
    }
}