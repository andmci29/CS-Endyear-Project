using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject debrisObstacle;
    public GameObject obstacle;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = 1f;
    public float maxY = 1f;
    public float z = 0f;
    public float spawnInterval = 1.5f;
    private float timer = 0f;
    private int debrisCount = 0;
    private int intervalCount = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawn(obstacle);
            timer = 0f;
            debrisCount++;
            intervalCount++;
        }
        if (debrisCount == 4)
        {
            SpawnDebris(debrisObstacle);
            debrisCount = 0;
        }
        if (intervalCount == 100)
        {
            spawnInterval -= 0.02f;
            intervalCount = 0;
        }
    }

    void Spawn(GameObject obstacle)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, z);
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }

    void SpawnDebris(GameObject obstacle)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomRot = Random.Range(0f, 360f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, randomRot);
        Vector3 spawnPosition = new Vector3(randomX, randomY, z);
        Instantiate(obstacle, spawnPosition, rotation);
        Debug.Log("debris spawned");
    }
}