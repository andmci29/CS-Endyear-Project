using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public float offset = 5f;

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);
    }
}