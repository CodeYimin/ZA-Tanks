using UnityEngine;

namespace Events
{
    public class CollisionEvent
    {
        public Collider2D[] colliders;
        public MoveEvent moveEvent;
        
        public CollisionEvent(Collider2D[] colliders, MoveEvent moveEvent)
        {
            this.colliders = colliders;
            this.moveEvent = moveEvent;
        }
    }
}