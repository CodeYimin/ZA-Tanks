using System.Collections;
using UnityEngine;

namespace Collision
{
    public class BounceOnCollision : MonoBehaviour
    {
        [SerializeField] string[] collisionTags;
        Rigidbody2D myRigidbody;
        
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }
        
        void OnCollisionEnter2D(Collision2D other)
            {
                if (((IList) collisionTags).Contains(other.gameObject.tag))
                {
                    ContactPoint2D hit = other.GetContact(0);
                    myRigidbody.velocity = Vector2.Reflect(myRigidbody.velocity, hit.normal); 
                }
        
            }
    }
}