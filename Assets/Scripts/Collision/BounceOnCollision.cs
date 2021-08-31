using System.Collections;
using System.Linq;
using UnityEngine;

namespace Collision
{
    public class BounceOnCollision : MonoBehaviour
    {
        [SerializeField] private string[] collisionTags;
        private Rigidbody2D _myRigidbody;
        
        private Vector2 _previousContactPoint;
        private float _previousContactTime;

        private void Start()
        {
            _myRigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ContactPoint2D contact = collision.GetContact(0);
            
            if (!collisionTags.Contains(collision.collider.tag)) return;
            if (Time.time == _previousContactTime && contact.point == _previousContactPoint) return;
            
            _previousContactTime = Time.time;
            _previousContactPoint = contact.point;

            _myRigidbody.velocity = Vector2.Reflect(_myRigidbody.velocity, contact.normal);
        }
    }
}