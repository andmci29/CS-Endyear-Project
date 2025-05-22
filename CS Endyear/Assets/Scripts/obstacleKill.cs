using UnityEngine;

public class obstacleKill : MonoBehaviour
{
    public GameObject self;
    public Rigidbody rb;
    public float force;
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0f, 0f, -force);
        if (transform.position.z < -10)
        {
            Destroy(self);
        }
    }
}
