using UnityEngine;

public class jump : MonoBehaviour
{
    public float flapForce = 300f;
    public float forwardSpeed = 5f;
    public float gravityMultiplier = 3f;
    public float maxUpwardVelocity = 5f;
    public Rigidbody rb;

    void Update()
    {
        rb.linearVelocity = new Vector3(forwardSpeed, rb.linearVelocity.y, rb.linearVelocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);

            if (rb.linearVelocity.y > maxUpwardVelocity)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, maxUpwardVelocity, rb.linearVelocity.z);
            }
        }

        rb.AddForce(Physics.gravity * (gravityMultiplier - 1) * rb.mass);
    }
}