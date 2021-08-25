using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event Action OnFire;
    
    enum FireMode
    {
        TapToFire,
        HoldToFire
    }

    [SerializeField] FireMode fireMode;
    [SerializeField] string fireButton;
    [SerializeField] float cooldownMs;

    float nextFireTime;

    void Start()
    {
        OnFire += AddCooldown;
    }
    
    void Update()
    {
        if (!OnCooldown())
        {
            Fire();
        }
    }
    
    void Fire()
    {
        switch (fireMode)
        {
            case FireMode.TapToFire:
                // if (Input.GetButtonDown(fireButton)) OnFire?.Invoke();
                break;
            case FireMode.HoldToFire:
                // if (Input.GetButton(fireButton)) OnFire?.Invoke();
                break;
        }
    }

    bool OnCooldown()
    {
        return nextFireTime > Time.time;
    }

    void AddCooldown()
    {
        nextFireTime = Time.time + cooldownMs / 1000;
    }
    
    
}
