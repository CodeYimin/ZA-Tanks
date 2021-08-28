using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class ClunkyMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5;
        [SerializeField] private float backwardsMoveSlowdown = 0.5f;
        [SerializeField] private float rotateSpeed = 180;
        [SerializeField] private string[] collisionTags;

        private Vector2 _movementInput;

        private void OnMovement(InputValue value)
        {
            _movementInput = value.Get<Vector2>();
        }
        
        private void Update()
        {
            // Tank forward/backward movement
            float inputY = _movementInput.y;
            Vector2 direction = transform.up;
            Vector2 moveVelocity = direction * (inputY * moveSpeed);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (inputY == -1)
            {
                moveVelocity *= backwardsMoveSlowdown;
            }
    
            // Tank rotation
            float inputX = _movementInput.x;
            float angularVelocity = -inputX * rotateSpeed;
        
            MoveAndRotate(moveVelocity, angularVelocity);
        }

        private void MoveAndRotate(Vector3 moveVelocity, float angularVelocity)
        {
            Vector3 newPosition = transform.position + moveVelocity * Time.deltaTime;
            float newRotation = transform.eulerAngles.z + angularVelocity * Time.deltaTime;
        
            Collider2D[] overlaps = Physics2D.OverlapBoxAll(newPosition, transform.lossyScale, newRotation);
            Collider2D[] collisionOverlaps = overlaps.Where((overlap) => collisionTags.Contains(overlap.tag)).ToArray();
        
            if (collisionOverlaps.Length == 0)
            {
                transform.position = newPosition;
                transform.rotation = Quaternion.Euler(Vector3.forward * newRotation);
            }
        }
    }
}