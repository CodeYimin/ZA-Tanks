using System;
using UnityEngine;

namespace Weapons
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private Transform muzzle;
        [SerializeField] private float projectileSpeed = 5;
        [SerializeField] private float projectileDuration = 5;

        void OnFire()
        {            
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
            newProjectile.SetSpeed(projectileSpeed);
            
            Temporary projectileLifetime = newProjectile.gameObject.AddComponent<Temporary>();
            projectileLifetime.SetDuration(projectileDuration);
        }
    }
}