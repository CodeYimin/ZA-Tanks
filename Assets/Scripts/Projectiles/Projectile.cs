using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    
    Rigidbody2D myRigidbody;
    
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = transform.up * speed;
    }

    public void SetSpeed(float newSpeed)
    {
        myRigidbody.velocity = transform.up * newSpeed;
    }
}
