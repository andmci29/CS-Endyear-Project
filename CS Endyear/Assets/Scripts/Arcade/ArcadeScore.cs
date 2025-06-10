using UnityEngine;
using TMPro;

public class ArcadeScore : MonoBehaviour
{
    private float timer = 0.0f;
    private int scoreDisplay = 0;
    public float scoreInterval = 1.0f;
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= scoreInterval)
        {
            timer = 0;
            scoreDisplay += 25;
        }

        scoreText.text = "Distance traveled: " + scoreDisplay.ToString() + "m";
    }
}
