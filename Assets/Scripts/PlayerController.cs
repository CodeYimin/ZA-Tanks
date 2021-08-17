using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    
    void Update()
    {
        float inputY = Input.GetAxisRaw("Vertical");
        float moveVelocity = inputY * moveSpeed;
        Move(moveVelocity);
        
        float inputX = Input.GetAxisRaw("Horizontal");
        float rotateVelocity = -inputX * rotateSpeed;
        Rotate(rotateVelocity);
    }

    void Move(float velocity)
    {
        Vector3 direction = transform.up;
        Vector3 futurePosition = transform.position + direction * (velocity * Time.deltaTime);

        Collider2D[] overlaps =
            Physics2D.OverlapBoxAll(futurePosition, transform.lossyScale, transform.eulerAngles.z);
        Collider2D[] wallOverlaps = overlaps.Where((overlap) => overlap.CompareTag("Wall")).ToArray();

        if (wallOverlaps.Length == 0)
        {
            transform.position = futurePosition;
        }
    }

    void Rotate(float velocity)
    {
        float futureRotation = transform.eulerAngles.z + velocity * Time.deltaTime;
        
        Collider2D[] overlaps =
            Physics2D.OverlapBoxAll(transform.position, transform.lossyScale, futureRotation);
        Collider2D[] wallOverlaps = overlaps.Where((overlap) => overlap.CompareTag("Wall")).ToArray();

        if (wallOverlaps.Length == 0)
        {
            transform.Rotate(Vector3.forward * (velocity * Time.deltaTime));
        }
    }
    
}
