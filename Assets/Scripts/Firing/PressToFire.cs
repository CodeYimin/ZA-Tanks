using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToFire : MonoBehaviour
{
    [SerializeField] string button;
    
    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            SendMessage("OnFire");
        }
    }
}
