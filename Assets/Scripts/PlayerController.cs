using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    
    void Update()
    {
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 moveVelocity = Vector2.up * (inputY * moveSpeed);
        transform.Translate(moveVelocity * Time.deltaTime, Space.Self);

        float inputX = Input.GetAxisRaw("Horizontal");
        Vector3 rotateVelocity = Vector3.back * (inputX * rotateSpeed);
        transform.Rotate(rotateVelocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
    }
}
