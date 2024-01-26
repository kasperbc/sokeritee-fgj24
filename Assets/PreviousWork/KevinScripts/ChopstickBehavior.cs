using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickBehavior : MonoBehaviour
{
    private float timeOnGround;

    
    public void SetGroundTime(float time)
    {
        timeOnGround = time;
    }

    private void Update()
    {
        
        if (timeOnGround > 0f)
        {
            timeOnGround -= Time.deltaTime;
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
}
