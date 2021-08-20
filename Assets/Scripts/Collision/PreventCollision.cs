using System.Linq;
using Events;
using UnityEngine;

namespace Collision
{
    public class PreventCollision : MonoBehaviour
    {
        [SerializeField] string[] tags;
        CollisionController collisionController;
        void Start()
        {
            collisionController = GetComponent<CollisionController>();
            collisionController.OnWillCollide += OnWillCollide;
        }

        void OnWillCollide(CollisionEvent collisionEvent)
        {
            if (collisionEvent.colliders.Where((c) => tags.Contains(c.tag)).ToArray().Length > 0)
            {
                collisionEvent.moveEvent.cancelled = true;
            }
        }
    }
}