using UnityEngine;
using TMPro;

public class score : MonoBehaviour
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
            scoreDisplay++;
        }

        scoreText.text = "Score: " + scoreDisplay.ToString();
    }
}
