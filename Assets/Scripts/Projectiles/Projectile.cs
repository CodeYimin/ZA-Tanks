using UnityEngine;

namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
    
        private Rigidbody2D _myRigidbody;

        private void Awake()
        {
            _myRigidbody = GetComponent<Rigidbody2D>();
            _myRigidbody.velocity = transform.up * speed;
        }

        public void SetSpeed(float newSpeed)
        {
            _myRigidbody.velocity = transform.up * newSpeed;
        }
    }
}
