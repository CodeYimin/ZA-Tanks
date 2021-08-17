using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    Rigidbody2D myRigidBody;
    Vector2 moveVelocity;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float inputY = Input.GetAxisRaw("Vertical");
        moveVelocity = Vector2.up * (inputY * moveSpeed);
        
        float inputX = Input.GetAxisRaw("Horizontal");
        float rotateVelocity = inputX * rotateSpeed;
        transform.Rotate(Vector3.forward, -rotateVelocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        transform.Translate(moveVelocity * Time.fixedDeltaTime);
    }
}
