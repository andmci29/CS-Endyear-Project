using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public static string display = "";

    public void SetDisplay(string input)
    {
        display = input;
    }

    public string GetDisplay()
    {
        return display;
    }
}
