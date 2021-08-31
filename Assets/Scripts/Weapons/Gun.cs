using System;
using Effects;
using Projectiles;
using UnityEngine;

namespace Weapons
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private Transform muzzle;
        [SerializeField] private float projectileSpeed = 5;
        [SerializeField] private float projectileDuration = 5;

        private void OnFire()
        {            
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
            newProjectile.SetSpeed(projectileSpeed);
            newProjectile.transform.Translate(Vector3.up * newProjectile.transform.localScale.y / 2, Space.Self);
            
            Temporary projectileLifetime = newProjectile.gameObject.AddComponent<Temporary>();
            projectileLifetime.SetDuration(projectileDuration);
        }
    }
}