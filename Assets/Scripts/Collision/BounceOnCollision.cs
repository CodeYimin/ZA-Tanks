using System.Collections;
using System.Linq;
using UnityEngine;

namespace Collision
{
    public class BounceOnCollision : MonoBehaviour
    {
        [SerializeField] private string[] collisionTags;
        private Rigidbody2D _myRigidbody;

        private float _lastCollisionTime;

        private void Start()
        {
            _myRigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Time.time == _lastCollisionTime || !collisionTags.Contains(collision.collider.tag)) return;
            
            _lastCollisionTime = Time.time;
            ContactPoint2D hit = collision.GetContact(0);
            _myRigidbody.velocity = Vector2.Reflect(_myRigidbody.velocity, hit.normal);
            
        }
    }
}