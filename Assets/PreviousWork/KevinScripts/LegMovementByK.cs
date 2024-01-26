using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovementByK : MonoBehaviour
{
    public Transform RightLeg;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float maxForwardAngle = 90f;
    [SerializeField] private float maxBackwardAngle = -40f;
   

    private bool isRotating = false;
    private int rotationDirection = -1;

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }
    }

    void FixedUpdate()
    {
        if (isRotating)
        {
            RotateLeftLeg();
        }
    }

    void RotateLeftLeg()
    {
        float rotationAmount = rotationSpeed * Time.fixedDeltaTime;


        float currentAngle = RightLeg.localRotation.eulerAngles.z;


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


        RightLeg.localRotation = Quaternion.Euler(0f, 0f, newAngle);
    }
}
