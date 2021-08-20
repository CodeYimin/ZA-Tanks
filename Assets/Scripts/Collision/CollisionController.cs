using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Types;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public event Action<CollisionEvent> OnWillCollide;
    
    enum Shape
    {
        Box,
        Circle
    }

    [SerializeField] Shape shape = Shape.Box;
    MovementController movementController;

    void Start()
    {
        movementController = GetComponent<MovementController>();
        movementController.OnMove += OnMove;
    }

    void OnMove(MoveEvent moveEvent)
    {
        Collider2D[] colliders = CheckForCollisions(moveEvent.to);
        
        if (colliders.Length > 0 && OnWillCollide != null)
        {
            OnWillCollide(new CollisionEvent(colliders, moveEvent));
        }
    }

    Collider2D[] CheckForCollisions(Position2D position2D)
    {
        Collider2D[] colliders = new Collider2D[0];
        
        switch (shape)
        {
            case Shape.Box:
                colliders = CheckForBoxCollisions(position2D);
                break;
            case Shape.Circle:
                break;
        }

        return colliders;
    }

    Collider2D[] CheckForBoxCollisions(Position2D position2D)
    {
        Collider2D[] overlaps =
            Physics2D.OverlapBoxAll(position2D.location, transform.lossyScale, position2D.rotation);
        return overlaps;
    }
}
