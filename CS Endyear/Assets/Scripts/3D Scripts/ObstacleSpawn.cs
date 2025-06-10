using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject tieVisual;
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
    private int intervalThreshold = 150;

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
        if (debrisCount == intervalThreshold / 15)
        {
            int chance = (int)(Random.Range(1, 6));
            if (chance == 1)
            {
                SpawnHorizontalDebris(debrisObstacle);
            }
            else
            {
                SpawnDebris(debrisObstacle);
            }
            debrisCount = 0;
        }
        if (intervalCount == intervalThreshold)
        {
            spawnInterval -= 0.01f;
            if (spawnInterval < 0.05f)
            {
                spawnInterval = 0.05f;
            }
            intervalThreshold += 30;
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
        float randomX = Random.Range(-120, 120);
        float randomRot = Random.Range(160f, 220f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, randomRot);
        Quaternion tieRotation = Quaternion.Euler(0f, 0f, randomRot + 90f);
        Vector3 spawnPosition = new Vector3(randomX, 250, z);
        Instantiate(obstacle, spawnPosition, rotation);
        Instantiate(tieVisual, spawnPosition, tieRotation);
    }

    void SpawnHorizontalDebris(GameObject obstacle)
    {
        float x = 165f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, 90f);
        Quaternion tieRotation = Quaternion.Euler(0f, 0f, 180f);
        int chance = (int)(Random.Range(1, 3));
        if (chance == 1)
        {
            x = -165f;
            rotation = Quaternion.Euler(0f, 0f, -90f);
        }


        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(x, randomY, z);
        Instantiate(obstacle, spawnPosition, rotation);
        Instantiate(tieVisual, spawnPosition, tieRotation);
    }
}