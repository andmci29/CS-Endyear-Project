using UnityEngine;

public class AsteroidRotate : MonoBehaviour
{
    private float timer = 0.0f;
    private float interval = 0.01f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            transform.Rotate(0.0f, 0.0f, Random.Range(0.1f, 0.6f));
            timer = 0.0f;
        }
    }
}
