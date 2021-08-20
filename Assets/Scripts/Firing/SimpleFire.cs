using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFire : MonoBehaviour
{

    [SerializeField] Transform muzzle;
    [SerializeField] Projectile projectile;
    [SerializeField] float projectileVelocity;
    [SerializeField] float projectileDuration;
    
    void OnFire()
    {
        Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
        Temporary temporary = newProjectile.gameObject.AddComponent<Temporary>();
        temporary.setDuration(projectileDuration);
    }
}
