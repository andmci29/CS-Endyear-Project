using UnityEngine;

public class ShipFlight2D : MonoBehaviour
{
    public float thrust = 20f;
    public float bankAngle = 15f;
    public float bankSpeed = 3f;
    public float forwardMovement = 5f;
    public Rigidbody rb;

    private float currentBankAngle = 0f;

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(forwardMovement, 0.0f, 0.0f));

        Vector3 movement = new Vector3(0.0f, moveVertical, 0.0f);

        if (Vector3.Dot(rb.linearVelocity.normalized, movement.normalized) < 0)
        {
            rb.AddForce(movement * thrust * 2f * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(movement * thrust * Time.deltaTime, ForceMode.Impulse);
        }

        float targetBankAngle = moveVertical * bankAngle;

        currentBankAngle = Mathf.Lerp(currentBankAngle, targetBankAngle, bankSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(currentBankAngle, 0, 0);
    }
}