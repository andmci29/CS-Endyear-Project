using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    private float timer = 0.0f;
    private int scoreDisplay;
    public float scoreInterval = 1.0f;
    public TextMeshProUGUI scoreText;
    public SceneFade sceneFade;

    void Start()
    {
        scoreDisplay = (int)(Random.Range(20000f, 28000f));
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= scoreInterval)
        {
            timer = 0;
            scoreDisplay -= 25;
        }

        scoreText.text = "Distance to hyperspace jump: " + scoreDisplay.ToString() + "m";

        if (scoreDisplay <= 0)
        {
            SceneTransition.LoadHyperspace("3D", "2D");
        }
    }
}
