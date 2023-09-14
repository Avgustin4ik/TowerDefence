using UnityEngine;

namespace _GameLogic_.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Configs/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public float CastleHealth { get; private set; }
        [field: SerializeField] public float WaveDuration { get; private set; }
        
        [field: SerializeField] public float MaxEnemyCount { get; private set; }
        [field: SerializeField] public float EnemySpawnDelay { get; private set; }
    }

    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public float DefaultEnemyHp { get; private set; }
        // [field: SerializeField] public float DefaultEnemySpeed { get; private set; }
        [field: SerializeField] public float DefaultEnemyDamage { get; private set; }
        [field: SerializeField] public float DefaultEnemyReward { get; private set; }
    }
}