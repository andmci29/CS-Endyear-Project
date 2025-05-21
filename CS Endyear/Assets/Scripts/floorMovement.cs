using UnityEngine;

public class floorMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, -0.25f);
        transform.Translate(movement);

        if (transform.position.z < -60)
        {
            transform.position = new Vector3(0.0f, 0.0f, 80);
        }
    }
}
