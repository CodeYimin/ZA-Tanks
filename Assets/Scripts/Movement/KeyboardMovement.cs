using System;
using UnityEngine;

namespace Movement
{
    public class KeyboardMovement : MonoBehaviour
    {
        
        [SerializeField] float moveSpeed = 5;
        [SerializeField] float backwardsMovingSlowdown = 0.5f;
        [SerializeField] float rotateSpeed = 180;
        MovementManager movementManager;
        
        void Awake()
        {
            movementManager = GetComponent<MovementManager>();
        }
        
        void Update()
        {
            // Vertical movement
            float inputY = Input.GetAxisRaw("Vertical");
            Vector2 direction = transform.up;
            Vector2 locationVelocity = direction * (inputY * moveSpeed);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (inputY == -1) locationVelocity *= backwardsMovingSlowdown;

            // Horizontal rotation
            float inputX = Input.GetAxisRaw("Horizontal");
            float rotationVelocity = -inputX * rotateSpeed;
            
            movementManager.MoveAndRotate(locationVelocity, rotationVelocity);
        }
    }
}