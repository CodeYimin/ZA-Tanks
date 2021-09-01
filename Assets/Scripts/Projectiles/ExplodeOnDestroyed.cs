using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;
using Projectiles;

public class ExplodeOnDestroyed : MonoBehaviour
{

    [SerializeField] private Projectile shrapnelThroughWall;
    [SerializeField] private Projectile shrapnelStopAtWall;
    [SerializeField] private float projectileSpeed = 5;
    [SerializeField] private float projectileDuration = 5;
    [SerializeField] private int numberOfProjectiles = 5;
    [SerializeField] private bool wallCollision = true;
    
    void OnDestroy() {
        

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Projectile newProjectile = Instantiate(shrapnelThroughWall, transform.position, transform.rotation);
            transform.eulerAngles = this.transform.forward * Random.Range(0, 360);
            newProjectile.SetSpeed(projectileSpeed);
            newProjectile.transform.Translate(Vector3.up * newProjectile.transform.localScale.y / 2, Space.Self);
            
            Temporary projectileLifetime = newProjectile.gameObject.AddComponent<Temporary>();
            projectileLifetime.SetDuration(projectileDuration);
        }
    }
}
