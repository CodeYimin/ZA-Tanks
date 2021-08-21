using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    HealthSystem myHealthSystem;
    
    void Start()
    {
        myHealthSystem = GetComponent<HealthSystem>();
        myHealthSystem.OnHealthChange += OnHealthChange;
    }

    void OnHealthChange(float newHealth)
    {
        if (newHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
