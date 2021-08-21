using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    enum Collider
    {
        Self,
        Other,
        Both
    }

    [SerializeField] string[] collisionTags;
    [SerializeField] float damage = 1;
    [SerializeField] Collider affectedCollider;

    void OnCollisionEnter2D(Collision2D collision)
    {
        HealthSystem myHealthSystem = collision.otherCollider.GetComponent<HealthSystem>();
        HealthSystem otherHealthSystem = collision.collider.GetComponent<HealthSystem>();

        if (collisionTags.Contains(collision.collider.tag))
        {
            switch (affectedCollider)
            {
                case Collider.Self:
                    if (myHealthSystem != null)
                    {
                        myHealthSystem.TakeDamage(damage);
                    }
                    break;
                case Collider.Other:
                    if (otherHealthSystem != null)
                    {
                        otherHealthSystem.TakeDamage(damage);
                    }
                    break;
                case Collider.Both:
                    if (myHealthSystem != null && otherHealthSystem != null)
                    {
                        myHealthSystem.TakeDamage(damage);
                        otherHealthSystem.TakeDamage(damage);
                    }
                    break;
            }
        }
    }
}
