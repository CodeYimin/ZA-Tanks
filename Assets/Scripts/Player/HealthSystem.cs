using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] float health = 1;

    void Update()
    {
        if (health <= 0)
        {
            SendMessage("OnDeath");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
