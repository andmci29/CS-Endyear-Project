using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float vertOffset = 10.0f;
    public float backwardOffset = 50f;

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0.0f, vertOffset, -backwardOffset);
        transform.position = player.position + offset;
    }
}
