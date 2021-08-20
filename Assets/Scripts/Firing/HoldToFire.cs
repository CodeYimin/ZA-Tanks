using System.Collections;
using System.Collections.Generic;
using Firing;
using UnityEngine;

public class HoldToFire : MonoBehaviour
{
    [SerializeField] string button;

    FireManager fireManager;
    
    void Start()
    {
        fireManager = GetComponent<FireManager>();
    }
    
    void Update()
    {
        if (Input.GetButton(button))
        {
            fireManager.Fire();
        }
    }
}
