using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float duration;
    private float durationPassed;
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
    
    public void SetDuration(float newDuration)
    {
        duration = newDuration;
    }
}
