using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    public event Action<GameObject> OnPlayerSpawn;

    private void Awake()
    {
        SpawnPlayers();
    }

    public void SpawnPlayers()
    {
        PlayerInput player1 = PlayerInput.Instantiate(playerPrefab, 0, "Keyboard Left", -1, Keyboard.current);
        OnPlayerSpawn?.Invoke(player1.gameObject);
        PlayerInput player2 = PlayerInput.Instantiate(playerPrefab, 1, "Keyboard Right", -1, Keyboard.current);
        OnPlayerSpawn?.Invoke(player2.gameObject);
    }
}
