using _GameLogic_.Castle.Views;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class EnemySystems : Feature
    {
        public EnemySystems(Contexts contexts)
        {
            Add(new NavMeshMovingSystem(contexts));
            Add(new EnemyAttackSystem(contexts));
            Add(new EnemyDetectTargetSystem(contexts));
            // Add(new EnemyDeathSystem(contexts));
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
            var enemyView = UnityEngine.Object.FindObjectOfType<EnemyView>();
            var pointView = UnityEngine.Object.FindObjectOfType<CastleView>();
            var enemyEntity = _contextsGame.CreateEntity();
            enemyView.Link(enemyEntity);
            enemyEntity.AddAttackDamage(4f);
            enemyEntity.AddNMAgentDestination(pointView.transform.position);
        }
    }
}