using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegRotator : MonoBehaviour
{
    public KeyCode rotateL;
    public KeyCode rotateR;

    public float rotateSpeed;

    void Update()
    {
        if (Input.GetKey(rotateL))
        {
            RotateLegs(-1);
        }
        else if (Input.GetKey(rotateR))
        {
            RotateLegs(1);
        }
    }

    void RotateLegs(float direction)
    {
        transform.Rotate((Vector3.up * direction) * rotateSpeed * Time.deltaTime);
    }
}
