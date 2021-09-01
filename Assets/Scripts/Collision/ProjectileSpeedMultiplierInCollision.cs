using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Projectiles;
using UnityEngine;

public class ProjectileSpeedMultiplierInCollision : MonoBehaviour
{

    [SerializeField] private float speedMultiplier = 0.5f;
    [SerializeField] private string[] collisionTags; 
    private Projectile projectile;

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
    } 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collisionTags.Contains(collision.collider.tag)) return;
        
        projectile.Speed *= speedMultiplier;
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!collisionTags.Contains(collision.collider.tag)) return;
        
        projectile.Speed /= speedMultiplier;
            
    }
}
