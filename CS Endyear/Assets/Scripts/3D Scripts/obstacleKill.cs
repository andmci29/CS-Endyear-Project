using UnityEngine;

public class obstacleKill : MonoBehaviour
{
    public GameObject self;

    public int killZ = 0;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < killZ)
        {
            Destroy(self);
        }
    }
}
