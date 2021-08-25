using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] FireMode fireMode;
    [SerializeField] float cooldownMs;
    
    public event Action OnFire;
    
    private enum FireMode
    {
        TapToFire,
        HoldToFire
    }

    private float nextFireTime;
    private bool fireInput;
    private bool tapToFireLock;
    private int hi = 1;

    public void OnFireInput(InputAction.CallbackContext context)
    {
        hi = 2;
        print(hi);
        // fireInput = context.ReadValueAsButton();
        // if (!fireInput)
        // {
        //     tapToFireLock = false;
        // }
    }
    
    private void Start()
    {
        OnFire += AddCooldown;
    }
    
    private void Update()
    {
        print(hi);
        if (!IsOnCooldown())
        {
            InvokeFireEvent();
        }
    }
    
    private void InvokeFireEvent()
    {
        switch (fireMode)
        {
            case FireMode.TapToFire:
                if (fireInput && !tapToFireLock)
                {
                    print("fire");
                    OnFire?.Invoke();
                    tapToFireLock = true;
                }
                break;
            case FireMode.HoldToFire:
                if (fireInput)
                {
                    OnFire?.Invoke();
                }
                break;
        }
    }

    bool IsOnCooldown()
    {
        return nextFireTime > Time.time;
    }

    void AddCooldown()
    {
        nextFireTime = Time.time + cooldownMs / 1000;
    }
    
    
}
