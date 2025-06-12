using UnityEngine;
using TMPro;

public class ScoreToText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public ScoreDisplay scoreD;

    void Start()
    {
        scoreText.text = scoreD.GetDisplay();
    }
}
