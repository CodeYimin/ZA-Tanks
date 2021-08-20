using System.Collections;
using System.Collections.Generic;
using Firing;
using UnityEngine;

public class TapToFire : MonoBehaviour
{
    [SerializeField] string button;

    FireManager fireManager;
    
    void Start()
    {
        fireManager = GetComponent<FireManager>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            fireManager.Fire();
        }
    }
}
