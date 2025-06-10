using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public Transform player;
    public GameObject obstacle;
    public GameObject circleObstacle;
    public GameObject tieFighter;
    public float spawnInterval = 1.5f;
    private float timer = 0f;
    public float minY = 1f;
    public float maxY = 1f;
    private int tieCount = 0;
    public int tieSpawnNum = 1;
    public int tieSpawnNumIncreaseNum = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawn(obstacle);
            SpawnCircle(circleObstacle);
            timer = 0f;
            tieCount++;
        }
        if (tieCount == 4)
        {
            for (int i = 0; i < tieSpawnNum; i++)
            {
                SpawnTie(tieFighter);
            }

            tieSpawnNumIncreaseNum++;

            if (tieSpawnNumIncreaseNum == 3)
            {
                tieSpawnNum++;
                tieSpawnNumIncreaseNum = 0;
            }

            if (tieSpawnNum > 5)
            {
                tieSpawnNum = 5;
            }

            tieCount = 0;
        }
    }

    void Spawn(GameObject obstacle)
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(player.position.x + 150, randomY, 0);
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }

    void SpawnCircle(GameObject circle)
    {
        float randomY = Random.Range(minY + 5f, maxY - 5f);
        float randomX = Random.Range(player.position.x + 170, player.position.x + 195);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        Quaternion rotate = Quaternion.Euler(90f, 0.0f, 0.0f);
        Instantiate(circle, spawnPosition, rotate);
    }

    void SpawnTie(GameObject tie)
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(player.position.x + 300, randomY, 0);
        Instantiate(tie, spawnPosition, Quaternion.identity);
    }
}




