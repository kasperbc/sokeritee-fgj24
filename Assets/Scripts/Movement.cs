using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0)
        {
            rb.AddForce(Vector3.right * movementSpeed);
        }
        else if (horizontalInput < 0)
        {
            rb.AddForce(-Vector3.right * movementSpeed);
        }

        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            rb.AddForce(Vector3.forward * movementSpeed);
        }
        else if (verticalInput < 0)
        {
            rb.AddForce(-Vector3.forward * movementSpeed);
        }

        //Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        //transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        //if (movementDirection != Vector3.zero)
        //{
        //    transform.forward = movementDirection;
        //}

        //rb.AddForce(movementDirection.normalized * movementSpeed);
    }
}
