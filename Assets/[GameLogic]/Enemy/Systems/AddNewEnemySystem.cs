using System;
using System.Collections.Generic;
using _GameLogic_.Data;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class AddNewEnemySystem : ReactiveSystem<GameEntity>
    {
        private readonly EnemyConfig _enemyConfig;
        private GameContext _contextsGame;

        public AddNewEnemySystem(Contexts contexts, EnemyConfig enemyConfig) : base(contexts.game)
        {
            _enemyConfig = enemyConfig;
            _contextsGame = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.WaveLevel);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var dataEntity = _contextsGame.gameDataEntity;
            var spawnerEntity = _contextsGame.enemySpawnerEntity;
            var waveLevel = dataEntity.waveLevel.value;
            var newEnemyCount = UnityEngine.Random.Range(waveLevel, waveLevel + _enemyConfig.MaxAdditionalEnemyCount);
            spawnerEntity.ReplaceEnemyAmount(spawnerEntity.enemyAmount.value + newEnemyCount);
        }
    }
}