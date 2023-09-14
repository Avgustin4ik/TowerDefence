using _GameCore_;
using DesperateDevs.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace _GameLogic_.Enemy
{
    public class EnemyView : View
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.isEnemy = true;
            entity.AddNavMeshAgent(navMeshAgent);
        }
    }
}