using UnityEngine;

public class ChopstickBehavior : MonoBehaviour
{
    private float timeOnGround;
    public float upwardSpeed = 30f;
    private Transform playerTransform; // Add a reference to the playerTransform

    public void SetGroundTime(float time)
    {
        timeOnGround = time;
    }

    public void SetPlayerTransform(Transform transform)
    {
        playerTransform = transform;
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
            // Move the chopstick upwards
            transform.Translate(Vector3.up * upwardSpeed * Time.deltaTime);

            // Move the player upwards if the playerTransform is set
            if (playerTransform != null)
            {
                playerTransform.Translate(Vector3.up * upwardSpeed * Time.deltaTime);
            }
        }
    }
}
