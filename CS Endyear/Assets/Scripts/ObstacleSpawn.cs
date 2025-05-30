using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = 1f;
    public float maxY = 1f;
    public float z = 0f;
    public int spawnRate = 1;

    void Update()
    {
        if ((int)(Random.Range(0, 100)) < spawnRate)
        {
            SpawnAtRandomX();
        }
    }

    void SpawnAtRandomX()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, z);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}