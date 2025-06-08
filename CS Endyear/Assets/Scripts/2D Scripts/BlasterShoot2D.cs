using UnityEngine;

public class BlasterShoot2D : MonoBehaviour
{
    public GameObject bolt;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Spawn(bolt);
        }
    }

    void Spawn(GameObject obstacle)
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        Vector3 spawnPosition = new Vector3(x, y, z);
        Quaternion rotation = Quaternion.Euler(-transform.rotation.x * 300, 90f, 90f);
        GameObject bolt = Instantiate(obstacle, spawnPosition, rotation);
    }
}
