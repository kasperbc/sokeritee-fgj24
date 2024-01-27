using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
      
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

       
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
