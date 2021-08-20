using System;
using Events;
using UnityEngine;

namespace Firing
{
    public class DestroyFiredProjectiles : MonoBehaviour
    {
        [SerializeField] float delaySeconds;

        FireManager fireManager;

        void Start()
        {
            fireManager = GetComponent<FireManager>();
            fireManager.OnProjectileSpawn += OnProjectileSpawn;
        }

        void OnProjectileSpawn(ProjectileSpawnEvent e)
        {
            
        }
    }
}