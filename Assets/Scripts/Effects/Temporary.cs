using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float duration;
    float durationPassed;
    void Update()
    {
        if (durationPassed < duration)
        {
            durationPassed += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void setDuration(float newDuration)
    {
        duration = newDuration;
    }
}
