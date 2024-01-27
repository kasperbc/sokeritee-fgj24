using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{
    public Transform leg;
    public KeyCode moveKey;
    public KeyCode moveBackKey;
    public KeyCode moveSideKey;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float maxForwardSideAngle = 0f;
    [SerializeField] private float maxBackwardSideAngle = -90f;
    private float sideRotationDirection;

    void FixedUpdate()
    {
        if (Input.GetKey(moveKey))
        {
            RotateLeg(1);
        }
        else if (Input.GetKey(moveBackKey))
        {
            RotateLeg(-1);
        }
        if (Input.GetKey(moveSideKey))
        {
            RotateLegSide();
        }
    }

    void RotateLeg(float rotationDirection)
    {
        float rotationAmount = rotationSpeed * Time.fixedDeltaTime;


        float currentAngle = leg.localRotation.eulerAngles.z;


        float newAngle = currentAngle + rotationAmount * rotationDirection;


        if (newAngle > 180f)
        {
            newAngle -= 360f;
        }

        leg.localRotation = Quaternion.Euler(leg.localEulerAngles.x, leg.localEulerAngles.y, newAngle);
    }

    void RotateLegSide()
    {
        float rotationAmount = rotationSpeed * Time.fixedDeltaTime;


        float currentAngle = leg.localRotation.eulerAngles.x;


        float newAngle = currentAngle + rotationAmount * sideRotationDirection;


        if (newAngle > 180f)
        {
            newAngle -= 360f;
        }


        if (newAngle >= maxForwardSideAngle || newAngle <= maxBackwardSideAngle)
        {
            sideRotationDirection *= -1; // Change direction
        }


        newAngle = Mathf.Clamp(newAngle, maxBackwardSideAngle, maxForwardSideAngle);

        
        leg.localRotation = Quaternion.Euler(newAngle, leg.localEulerAngles.y, leg.localEulerAngles.z);
    }
}
