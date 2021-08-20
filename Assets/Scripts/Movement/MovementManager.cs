using System;
using UnityEngine;

namespace Movement
{
    public class MovementManager: MonoBehaviour
    {
        public delegate void MoveAndRotateDelegate(Vector3 moveVelocity, float rotationVelocity);
        public event MoveAndRotateDelegate OnMoveAndRotate;

        public void MoveAndRotate(Vector3 moveVelocity, float rotationVelocity)
        {
            OnMoveAndRotate?.Invoke(moveVelocity, rotationVelocity);
        }
    }
}