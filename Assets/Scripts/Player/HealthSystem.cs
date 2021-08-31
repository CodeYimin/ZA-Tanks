using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event Action<float> OnHealthChange;
    
    [SerializeField] private float health = 1;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        OnHealthChange?.Invoke(health);
    }
}
