using Entitas;

namespace _GameLogic_.Data.Systems
{
    public class InitializeDataSystem : IInitializeSystem
    {
        public InitializeDataSystem(Contexts contexts)
        {
            
        }

        public void Initialize()
        {
            var data = Contexts.sharedInstance.game.CreateEntity();
            data.isGameData = true;
            data.AddSoftCurrency(0);
            data.AddWaveLevel(1);
            data.AddTimerAmount(30);//wave timer
        }
    }
}