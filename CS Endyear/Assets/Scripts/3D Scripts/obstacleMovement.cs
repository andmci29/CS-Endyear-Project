using UnityEngine;

public class floorMovement : MonoBehaviour
{
    public float speed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, -speed);
        transform.Translate(movement);
    }
}
