using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransition
{
    public static string previousScene;
    public static string targetScene;

    public static void LoadHyperspace(string fromScene, string toScene)
    {
        previousScene = fromScene;
        targetScene = toScene;
        SceneManager.LoadScene("Hyperspace");
    }

    public static void LoadTarget()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    public static string GetPreviousScene()
    {
        return previousScene;
    }

    public static string GetTargetScene()
    {
        return targetScene;
    }
}
