using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;  
    public Vector3 offset = new Vector3(0f, 2f, -5f);  
    public float smoothness = 5.0f;  

    void LateUpdate()
    {
        if (target != null)
        {
            
            Vector3 desiredPosition = target.position + offset;

            
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);
        }
    }
}
