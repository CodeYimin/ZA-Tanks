using System;
using System.Linq;
using UnityEngine;

namespace Collision
{
    public class DamageOnCollision : MonoBehaviour
    {
        private enum Collider
        {
            Self,
            Other,
            Both
        }

        [SerializeField] private string[] collisionTags;
        [SerializeField] private float damage = 1;
        [SerializeField] private Collider affectedCollider;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HealthSystem myHealthSystem = collision.otherCollider.GetComponent<HealthSystem>();
            HealthSystem otherHealthSystem = collision.collider.GetComponent<HealthSystem>();

            if (!collisionTags.Contains(collision.collider.tag)) return;
        
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
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
