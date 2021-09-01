using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;
using Projectiles;
using UnityEngine.PlayerLoop;

public class ExplodeOnDestroy : MonoBehaviour
{

    [SerializeField] private Projectile[] shrapnels;
    [SerializeField] private float projectileSpeed = 5;
    [SerializeField] private float projectileDuration = 5;
    [SerializeField] private int numberOfProjectiles = 5;
    [SerializeField] private int shrapnelType = 0;
    [SerializeField] private int speedVariance = 2;
    [SerializeField] private int timeVariance = 5;
    
    private void OnDestroy() {

        for (int _ = 0; _ < numberOfProjectiles; _++)
        {

            Projectile newProjectile = Instantiate(shrapnels[shrapnelType], transform.position, transform.rotation);
            newProjectile.transform.eulerAngles = Vector3.forward * Random.Range(0, 360);
            newProjectile.Speed = Random.Range(projectileSpeed-speedVariance, projectileSpeed +speedVariance);
            
            Temporary projectileLifetime = newProjectile.gameObject.AddComponent<Temporary>();
            projectileLifetime.SetDuration(Random.Range(projectileDuration-timeVariance,projectileDuration+timeVariance));
        }
    }
}
