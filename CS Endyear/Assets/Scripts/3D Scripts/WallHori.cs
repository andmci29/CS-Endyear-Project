using UnityEngine;

public class WallHori : MonoBehaviour
{
    public Transform player;
    public float showDistance = 2f;

    private Renderer wallRenderer;

    void Start()
    {
        wallRenderer = GetComponent<Renderer>();
        wallRenderer.enabled = false; // Start invisible

        // Find player if not assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            float zDistance = Mathf.Abs(player.position.z - transform.position.z);
            Debug.Log(zDistance);
            wallRenderer.enabled = zDistance <= showDistance;
        }
    }
}
