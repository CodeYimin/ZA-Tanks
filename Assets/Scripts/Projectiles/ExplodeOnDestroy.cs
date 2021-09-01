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
    [SerializeField] private bool wallCollision = true;

    private void OnDestroy() {

        for (int _ = 0; _ < numberOfProjectiles; _++)
        {
            int randIndex = Random.Range(0, shrapnels.Length - 1);
            
            Projectile newProjectile = Instantiate(shrapnels[randIndex], transform.position, transform.rotation);
            newProjectile.transform.eulerAngles = Vector3.forward * Random.Range(0, 360);
            newProjectile.Speed = projectileSpeed;
            
            Temporary projectileLifetime = newProjectile.gameObject.AddComponent<Temporary>();
            projectileLifetime.SetDuration(projectileDuration);
        }
    }
}
