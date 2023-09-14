using _GameLogic_.Enemy;

namespace _GameCore_.Core
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new EnemySystems(contexts));
            // Add(new PlayerSystems(_gameContext));
            // Add(new TowerSystems(_gameContext));
            // Add(new UiSystems(_gameContext));
            // Add(new TurnSystems(_gameContext));
        }
    }
}