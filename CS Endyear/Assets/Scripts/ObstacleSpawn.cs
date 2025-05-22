using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float minX = -5f;
    public float maxX = 5f;
    public float y = 1f;
    public float z = 0f;

    void Update()
    {
        if ((int)(Random.Range(0, 100)) < 1)
        {
            SpawnAtRandomX();
        }
    }

    void SpawnAtRandomX()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 1, z);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}