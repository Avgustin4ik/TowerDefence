using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class EnemyDeathSystem : ReactiveSystem<GameEntity>
    {
        public EnemyDeathSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Destroy();
            }
        }
    }
}