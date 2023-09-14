using _GameLogic_.Castle.Systems;
using _GameLogic_.Common;
using _GameLogic_.Enemy;
using _GameLogic_.Towers.Systems;
using Entitas;

namespace _GameCore_.Core
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new GeneralGameSystems(contexts));
            Add(new EnemySystems(contexts));
            Add(new CastleSystems(contexts));
            Add(new TowerSystems(contexts));
            // Add(new UiSystems(_gameContext));
            // Add(new TurnSystems(_gameContext));
            
        }
    }
}