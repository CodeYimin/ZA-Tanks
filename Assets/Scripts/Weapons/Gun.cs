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
        [SerializeField] private float projectileScale = 0.4f;

        private void OnFire()
        {            
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
            newProjectile.transform.localScale = Vector3.one * projectileScale;
            newProjectile.Speed = projectileSpeed;
            newProjectile.transform.Translate(Vector3.up * newProjectile.transform.localScale.y / 2, Space.Self);
            
            Temporary projectileLifetime = newProjectile.gameObject.AddComponent<Temporary>();
            projectileLifetime.SetDuration(projectileDuration);
        }
    }
}