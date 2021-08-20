using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] string[] collisionTags = new string[0]; 
    Rigidbody2D myRigidbody;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (collisionTags.Contains(other.gameObject.tag))
        {
            ContactPoint2D hit = other.GetContact(0);
            myRigidbody.velocity = Vector2.Reflect(myRigidbody.velocity, hit.normal); 
        }

    }
}
