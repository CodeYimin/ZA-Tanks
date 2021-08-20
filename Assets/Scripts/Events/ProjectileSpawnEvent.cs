using UnityEngine;

namespace Events
{
    public class ProjectileSpawnEvent
    {
        public Projectile projectile;
        public Vector2 position;
        public float rotation;
        public Vector2 velocity;
        public Vector2 scale;
        public bool cancelled = false;
        
        public ProjectileSpawnEvent(Projectile projectile, Vector2 position, float rotation, Vector2 velocity, Vector2 scale)
        {
            this.projectile = projectile;
            this.position = position;
            this.rotation = rotation;
            this.velocity = velocity;
            this.scale = scale;
        }
    }
}