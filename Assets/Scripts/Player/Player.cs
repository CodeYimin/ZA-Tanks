using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    HealthSystem _myHealthSystem;
    
    void Start()
    {
        _myHealthSystem = GetComponent<HealthSystem>();
        _myHealthSystem.OnHealthChange += OnHealthChange;
    }

    void OnHealthChange(float newHealth)
    {
        if (newHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
