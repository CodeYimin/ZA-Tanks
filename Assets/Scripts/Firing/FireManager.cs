using System;
using Events;
using UnityEngine;

namespace Firing
{
    public class FireManager : MonoBehaviour
    {
        public event Action<ProjectileSpawnEvent> OnProjectileSpawn;
        public event Action OnFire;
        
        [SerializeField] GameObject[] preventSpawnCollide;

        public void Fire()
        {
            OnFire?.Invoke();
        }

        public void SpawnProjectile(Projectile projectile, Vector2 position, float rotation = 0)
        {
            SpawnProjectile(projectile, position, rotation, Vector2.zero);
        }
        
        public void SpawnProjectile(Projectile projectile, Vector2 position, float rotation, Vector2 velocity)
        {
            SpawnProjectile(projectile, position, rotation, velocity, Vector2.one);
        }
        
        public void SpawnProjectile(Projectile projectile, Vector2 position, float rotation, Vector2 velocity, Vector2 scale)
        {
            ProjectileSpawnEvent projectileSpawnEvent = new ProjectileSpawnEvent(projectile, position, rotation, velocity, scale);
            OnProjectileSpawn?.Invoke(projectileSpawnEvent);

            if (!projectileSpawnEvent.cancelled)
            {
                InstantiateNewProjectile(projectile, position, rotation, velocity, scale);
            }
        }

        void InstantiateNewProjectile(Projectile projectile, Vector2 position, float rotation, Vector2 velocity, Vector2 scale)
        {
            Projectile newProjectile =
                Instantiate(projectile, position, Quaternion.Euler(Vector3.forward * rotation));
            newProjectile.GetComponent<Rigidbody2D>().velocity = velocity;
            newProjectile.transform.localScale = scale;
        }
        
        // To do prevent instant self spawn kill
    }
}