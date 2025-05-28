using UnityEngine;

public class ShipFlight : MonoBehaviour
{
    public float thrust = 20f;
    public Rigidbody rb;

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical / 1.5f, 0.0f);

        if (Vector3.Dot(rb.linearVelocity.normalized, movement.normalized) < 0)
        {
            rb.AddForce(movement * thrust * 2f, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(movement * thrust, ForceMode.Impulse);
        }
    }
}
