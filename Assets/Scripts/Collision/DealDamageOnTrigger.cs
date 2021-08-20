using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DealDamageOnTrigger : MonoBehaviour
{
    [SerializeField] string[] tags = new string[1] {"Player"};
    [SerializeField] float damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
    }
}
