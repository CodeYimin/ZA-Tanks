using System.Collections;
using System.Collections.Generic;
using Firing;
using UnityEngine;

public class SimpleFire : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] Projectile projectile;
    [SerializeField] Vector2 projectileVelocity;
    [SerializeField] float projectileDuration;

    FireManager fireManager;
    
    void Start()
    {
        fireManager = GetComponent<FireManager>();
        fireManager.OnFire += FireProjectile;
    }
    
    void Update()
    {

    }
    
    void FireProjectile()
    {
        fireManager.SpawnProjectile(projectile, muzzle.position, muzzle.eulerAngles.z, projectileVelocity);
    }
}
