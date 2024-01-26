using UnityEngine;

public class ArmMovementByI : MonoBehaviour
{
    public Transform armPivot;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float maxForwardAngle = 150f; 

    private bool isRotating = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
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
            RotateArm();
        }
    }

    void RotateArm()
    {
        float rotationAmount = rotationSpeed * Time.fixedDeltaTime;

        float newAngle = Mathf.PingPong(Time.time * rotationSpeed, maxForwardAngle);

        
        armPivot.localRotation = Quaternion.Euler(0f,-newAngle, newAngle);
    }
}
