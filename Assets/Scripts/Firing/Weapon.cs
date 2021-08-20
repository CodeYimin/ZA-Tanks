using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float cooldownSeconds;

    float nextFireTime;
    public void Fire()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + cooldownSeconds;
            SendMessage("OnFire");
        }
    }
}
