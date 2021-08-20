using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroySelfOnTrigger : MonoBehaviour
{
    [SerializeField] string[] tags;
    [SerializeField] int collisionAmount = 1;
    int currentCollisionAmount;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tags.Contains(other.tag))
        {
            if (currentCollisionAmount < collisionAmount)
            {
                currentCollisionAmount++;
            }

            if (currentCollisionAmount == collisionAmount)
            {
                Destroy(gameObject);
            }
        }
    }
}
