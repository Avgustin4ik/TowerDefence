namespace _GameLogic_.Data.Systems
{
    public class DataSystems : Feature
    {
        public DataSystems(Contexts contexts)
        {
            Add(new InitializeDataSystem(contexts));
            Add(new CollectSoftCurrencySystem(contexts));
            // Add(new EnemyAmountSystem(contexts));
            // Add(new WaveLevelSystem(contexts));
        }
    }
}