using UnityEngine;

namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D _myRigidbody;
        private float _speed;

        public float Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                _myRigidbody.velocity = transform.up * value;
            }
        }
        
        private void Awake()
        {
            _myRigidbody = GetComponent<Rigidbody2D>();
            _myRigidbody.velocity = transform.up * _speed;
        }
    }
}
