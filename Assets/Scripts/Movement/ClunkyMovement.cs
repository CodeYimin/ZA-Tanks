using System;
using System.Linq;
using UnityEngine;

namespace Movement
{
    public class ClunkyMovement : MonoBehaviour
    {
        [SerializeField] string[] collisionTags = new string[0];

        MovementManager movementManager;

        void Awake()
        {
            movementManager = GetComponent<MovementManager>();
            movementManager.OnMoveAndRotate += MoveAndRotate;
        }

        void MoveAndRotate(Vector3 moveVelocity, float rotationVelocity)
        {
            Vector3 newPosition = transform.position + moveVelocity * Time.deltaTime;
            float newRotation = transform.eulerAngles.z + rotationVelocity * Time.deltaTime;
            
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
