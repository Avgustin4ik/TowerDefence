using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _GameCore_
{
    public class View : MonoBehaviour, IGameEntityView
    {
        public GameEntity GameEntity;

        public virtual void Link(GameEntity entity)
        {
            GameEntity = entity;
            gameObject.Link(entity);
            entity.AddTransform(transform);
            entity.AddHashCode(GetHashCode());
            entity.OnDestroyEntity += EntityOnOnDestroyEntity;
        }

        private void EntityOnOnDestroyEntity(IEntity entity)
        {
            entity.OnDestroyEntity -= EntityOnOnDestroyEntity;
            gameObject.Unlink();

            GameEntity = null;
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (gameObject.GetEntityLink() == null) return;
            if (gameObject.GetEntityLink().entity == null) return;
            GameEntity?.Destroy();
        }
    }
}