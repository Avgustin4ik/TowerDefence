using _GameCore_;
using UnityEngine;

namespace _GameLogic_.Towers.Views
{
    public class TowerView : View
    {
        [SerializeField] private DetectionArea detectionArea;
        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.isTower = true;
            entity.AddTowerLevel(1);
            entity.AddDetectionArea(detectionArea.Bounds);
        }
    }
}