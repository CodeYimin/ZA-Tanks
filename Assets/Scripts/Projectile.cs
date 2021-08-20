using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250);
    }

    void Update()
    {
        // transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
