using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    enum Collider
    {
        Self,
        Other,
        Both
    }

    [SerializeField] string[] collisionTags;
    [SerializeField] Collider affectedCollider;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionTags.Contains(collision.collider.tag))
        {
            switch (affectedCollider)
            {
                case Collider.Self:
                    Destroy(collision.otherCollider.gameObject);
                    break;
                case Collider.Other:
                    Destroy(collision.collider.gameObject);
                    break;
                case Collider.Both:
                    Destroy(collision.otherCollider.gameObject);
                    Destroy(collision.collider.gameObject);
                    break;
            }
        }
    }

}
