using UnityEngine;

public class BlasterTravel : MonoBehaviour
{
    private Transform player;
    public GameObject self;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.x > player.position.x + 300)
        {
            Destroy(self);
        }
    }
}
