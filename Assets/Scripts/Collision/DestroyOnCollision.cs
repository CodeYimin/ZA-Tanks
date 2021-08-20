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

    [SerializeField] string[] collisionTags = new string[0];
    [SerializeField] Collider affectedCollider;


}
