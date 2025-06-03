using UnityEngine;

public class obstacleKill2D : MonoBehaviour
{
    private Transform player;
    public GameObject self;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (transform.position.x < player.position.x - 50)
        {
            Destroy(self);
        }
    }
}
