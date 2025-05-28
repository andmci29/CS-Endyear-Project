using UnityEngine;

public class ShipFlight : MonoBehaviour
{
    public float thrust = 20f;
    public Rigidbody rb;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical / 2, 0.0f);

        rb.AddForce(movement * thrust, ForceMode.Impulse);
    }
}
