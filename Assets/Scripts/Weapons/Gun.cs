using System;
using UnityEngine;

namespace Weapons
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] Projectile projectile;
        [SerializeField] Transform muzzle;
        [SerializeField] float projectileSpeed = 5;
        [SerializeField] float projectileDuration = 5;

        Weapon weapon;
        
        void Start()
        {
            weapon = GetComponent<Weapon>();
            weapon.OnFire += OnFire;
        }

        void OnFire()
        {
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
            newProjectile.SetSpeed(projectileSpeed);
            
            Temporary projectileLifetime = newProjectile.gameObject.AddComponent<Temporary>();
            projectileLifetime.setDuration(projectileDuration);
        }
    }
}