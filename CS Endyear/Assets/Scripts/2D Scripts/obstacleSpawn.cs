using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public Transform player;
    public GameObject obstacle;
    public float spawnInterval = 1.5f;
    private float timer = 0f;
    public float minY = 1f;
    public float maxY = 1f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawn(obstacle);
            timer = 0f;
        }
    }

    void Spawn(GameObject obstacle)
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(player.position.x + 50, randomY, 0);
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }
}
