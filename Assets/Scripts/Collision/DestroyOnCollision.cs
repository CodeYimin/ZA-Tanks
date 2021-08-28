using System;
using System.Linq;
using UnityEngine;

namespace Collision
{
    public class DestroyOnCollision : MonoBehaviour
    {
        private enum Collider
        {
            Self,
            Other,
            Both
        }

        [SerializeField] private string[] collisionTags;
        [SerializeField] private Collider affectedCollider;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collisionTags.Contains(collision.collider.tag)) return;
        
            switch (affectedCollider)
            {
                case Collider.Self:
                    Destroy(collision.otherCollider.gameObject);
                    break;
                case Collider.Other:
                    Destroy(collision.collider.gameObject);
                    break;
                case Collider.Both:
                    Destroy(collision.otherCollider.gameObject);
                    Destroy(collision.collider.gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
