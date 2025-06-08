using UnityEngine;

public class BlasterShoot : MonoBehaviour
{
    public GameObject bolt;
    public float spawnInterval = 1.0f;

    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawn(bolt);
            timer = 0f;
        }
    }

    void Spawn(GameObject obstacle)
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        Vector3 spawnPosition = new Vector3(x, y, z);
        Quaternion rotation = transform.rotation;
        GameObject bolt = Instantiate(obstacle, spawnPosition, rotation);

        BoltTravel boltScript = bolt.GetComponent<BoltTravel>();
        boltScript.SetTarget(this.transform);
    }
}
