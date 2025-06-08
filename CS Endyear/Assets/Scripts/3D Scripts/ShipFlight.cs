using UnityEngine;

public class ShipFlight : MonoBehaviour
{
    public float thrust = 20f;
    public float bankAngle = 15f;
    public float bankSpeed = 3f;
    public Rigidbody rb;

    private float currentBankAngle = 0f;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical / 1.5f, 0.0f);

        if (Vector3.Dot(rb.linearVelocity.normalized, movement.normalized) < 0)
        {
            rb.AddForce(movement * thrust * 2f * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(movement * thrust * Time.deltaTime, ForceMode.Impulse);
        }

        float targetBankAngle = -moveHorizontal * bankAngle;

        currentBankAngle = Mathf.Lerp(currentBankAngle, targetBankAngle, bankSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 180, -currentBankAngle);
    }
}
