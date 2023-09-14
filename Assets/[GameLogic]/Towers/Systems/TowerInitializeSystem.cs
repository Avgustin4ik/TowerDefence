using _GameLogic_.Towers.Views;
using Entitas;

namespace _GameLogic_.Towers.Systems
{
    public class TowerInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _contextsGame;

        public TowerInitializeSystem(Contexts contexts)
        {
            _contextsGame = contexts.game;
        }

        public void Initialize()
        {
            var towerViews = UnityEngine.Object.FindObjectsOfType<TowerView>();
            foreach (var towerView in towerViews)
            {
                var gameEntity = _contextsGame.CreateEntity();
                towerView.Link(gameEntity);
                gameEntity.AddAttackDamage(1);
                gameEntity.AddFireRate(1);
            }
        }
    }
}