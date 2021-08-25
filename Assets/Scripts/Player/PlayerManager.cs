using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.Instantiate(playerPrefab, 0, "Keyboard Left", -1, Keyboard.current);
        PlayerInput.Instantiate(playerPrefab, 1, "Keyboard Right", -1, Keyboard.current);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
