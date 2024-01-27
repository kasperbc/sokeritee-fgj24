using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{
    public Transform leg;
    public KeyCode moveKey;
    public KeyCode moveSideKey;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float maxForwardAngle = 90f;
    [SerializeField] private float maxBackwardAngle = -40f;
   

    private bool isRotating = false;
    private int rotationDirection = -1;

    void FixedUpdate()
    {
        if (Input.GetKey(moveKey))
        {
            RotateLeg();
        }
        if (Input.GetKey(moveSideKey))
        {
            RotateLegSide();
        }
    }

    void RotateLeg()
    {
        float rotationAmount = rotationSpeed * Time.fixedDeltaTime;


        float currentAngle = leg.localRotation.eulerAngles.z;


        float newAngle = currentAngle + rotationAmount * rotationDirection;


        if (newAngle > 180f)
        {
            newAngle -= 360f;
        }


        if (newAngle >= maxForwardAngle || newAngle <= maxBackwardAngle)
        {
            rotationDirection *= -1; // Change direction
        }


        newAngle = Mathf.Clamp(newAngle, maxBackwardAngle, maxForwardAngle);


        leg.localRotation = Quaternion.Euler(leg.localEulerAngles.x, leg.localEulerAngles.y, newAngle);
    }

    void RotateLegSide()
    {
        float rotationAmount = rotationSpeed * Time.fixedDeltaTime;


        float currentAngle = leg.localRotation.eulerAngles.x;


        float newAngle = currentAngle + rotationAmount * rotationDirection;


        if (newAngle > 180f)
        {
            newAngle -= 360f;
        }


        if (newAngle >= maxForwardAngle || newAngle <= maxBackwardAngle)
        {
            rotationDirection *= -1; // Change direction
        }


        newAngle = Mathf.Clamp(newAngle, maxBackwardAngle, maxForwardAngle);

        
        leg.localRotation = Quaternion.Euler(newAngle, leg.localEulerAngles.y, leg.localEulerAngles.z);
    }
}
