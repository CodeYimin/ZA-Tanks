using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float backwardsMoveSlowdown;
    [SerializeField] private float rotateSpeed;
    [SerializeField] string[] collisionTags = new string[0];

    private void Start()
    {
        print("mal");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        print("helo");
        // Vector2 movementInput = context.ReadValue<Vector2>();
        //
        // // Vertical movement
        // float inputY = movementInput.y;
        // Vector2 direction = transform.up;
        // Vector2 moveVelocity = direction * (inputY * moveSpeed);
        // // ReSharper disable once CompareOfFloatsByEqualityOperator
        // if (inputY == -1)
        // {
        //     moveVelocity *= backwardsMoveSlowdown;
        // }
        //
        // // Horizontal rotation
        // float inputX = movementInput.x;
        // float angularVelocity = -inputX * rotateSpeed;
        //     
        // MoveAndRotate(moveVelocity, angularVelocity);
    }

    void MoveAndRotate(Vector3 moveVelocity, float angularVelocity)
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
