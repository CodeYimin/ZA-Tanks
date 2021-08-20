using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Events;
using Types;
using Unity.Mathematics;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public event Action<MoveEvent> OnMove;

    Position2D position;

    void Start()
    {
        position = new Position2D(transform.position, transform.rotation.z);
    }

    public void Move(Vector2 locationVelocity, float rotationVelocity)
    {
        Position2D newPosition =
            new Position2D(position.location + locationVelocity * Time.deltaTime, position.rotation + rotationVelocity * Time.deltaTime);
        MoveEvent moveEvent = new MoveEvent(position, newPosition);
        
        if (OnMove != null)
        {
            OnMove(moveEvent);
        }
        
        if (!moveEvent.cancelled)
        {
            Vector2 newLocation = moveEvent.to.location;
            Vector3 newRotationVector = Vector3.forward * moveEvent.to.rotation;
            
            transform.position = newLocation;
            transform.rotation = Quaternion.Euler(newRotationVector);
            position = newPosition;
        }
    }

}
