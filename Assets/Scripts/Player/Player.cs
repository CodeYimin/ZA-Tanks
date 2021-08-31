using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthSystem _myHealthSystem;
    private PlayerManager _playerManager;
    
    private void Awake()
    {
        _myHealthSystem = GetComponent<HealthSystem>();
        _playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Start()
    {
        _myHealthSystem.OnHealthChange += OnHealthChange;
    }

    private void OnHealthChange(float newHealth)
    {
        if (newHealth <= 0)
        {
            _playerManager.DestroyPlayer(gameObject);
        }
    }
}
