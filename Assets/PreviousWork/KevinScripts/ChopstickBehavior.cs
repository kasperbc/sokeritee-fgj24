using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickBehavior : MonoBehaviour
{
    private float timeOnGround;
    public float upwardSpeed = 30f;

    
    public void SetGroundTime(float time)
    {
        timeOnGround = time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Disable the Rigidbody's physics behavior by setting it to kinematic
            Rigidbody chopstickRigidbody = GetComponent<Rigidbody>();
            if (chopstickRigidbody != null)
            {
                chopstickRigidbody.isKinematic = true;
            }
        }
    }

    private void Update()
    {
        
        if (timeOnGround > 0f)
        {
            timeOnGround -= Time.deltaTime;
        }
        else
        {
            
            transform.Translate(Vector3.up * upwardSpeed * Time.deltaTime);
        }
    }
}
