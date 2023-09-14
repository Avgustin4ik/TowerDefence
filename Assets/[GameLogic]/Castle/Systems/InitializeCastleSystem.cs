using _GameLogic_.Castle.Views;
using Entitas;

namespace _GameLogic_.Castle.Systems
{
    public class InitializeCastleSystem : IInitializeSystem
    {
        public InitializeCastleSystem(Contexts contexts)
        {
            
        }

        public void Initialize()
        {
            var castleEntity = Contexts.sharedInstance.game.CreateEntity();
            UnityEngine.Object.FindObjectOfType<CastleView>().Link(castleEntity);
            castleEntity.AddHealth(50);
        }
    }
}