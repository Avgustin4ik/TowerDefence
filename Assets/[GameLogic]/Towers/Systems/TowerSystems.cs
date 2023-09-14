namespace _GameLogic_.Towers.Systems
{
    public class TowerSystems : Feature
    {
        public TowerSystems(Contexts contexts)
        {
            Add(new TowerInitializeSystem(contexts));
            // Add(new TowerAttackSystem(contexts));
            // Add(new TowerDetectionAreaSystem(contexts));
        }
    }
}