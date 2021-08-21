using System.Collections;
using System.Linq;
using UnityEngine;

namespace Collision
{
    public class BounceOnCollision : MonoBehaviour
    {
        [SerializeField] string[] collisionTags;
        Rigidbody2D myRigidbody;

        float lastCollisionTime;
        
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }
        
        void OnCollisionEnter2D(Collision2D collision)
            {
                if (Time.time != lastCollisionTime && collisionTags.Contains(collision.collider.tag))
                {
                    lastCollisionTime = Time.time;
                    ContactPoint2D hit = collision.GetContact(0);
                    myRigidbody.velocity = Vector2.Reflect(myRigidbody.velocity, hit.normal); 
                }
        
            }
    }
}