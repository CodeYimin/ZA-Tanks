using System;
using UnityEngine;

namespace Movement
{
    public class KeyboardMovement : MonoBehaviour
    {
        
        [SerializeField] float moveSpeed = 5;
        [SerializeField] float backwardsMovingSlowdown = 0.5f;
        [SerializeField] float rotateSpeed = 180;
        MovementController movementController;
        
        void Start()
        {
            movementController = GetComponent<MovementController>();
        }
        
        void Update()
        {
            // Vertical movement
            float inputY = Input.GetAxisRaw("Vertical");
            Vector2 direction = transform.up;
            Vector2 locationVelocity = direction * (inputY * moveSpeed);
            if (inputY == -1) locationVelocity *= backwardsMovingSlowdown;

            // Horizontal rotation
            float inputX = Input.GetAxisRaw("Horizontal");
            float rotationVelocity = -inputX * rotateSpeed;
            
            movementController.Move(locationVelocity, rotationVelocity);
        }
    }
}