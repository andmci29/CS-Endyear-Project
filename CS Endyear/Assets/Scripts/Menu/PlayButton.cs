using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("3D");
    }

    public void Arcade3D()
    {
        SceneManager.LoadScene("3D Arcade");
    }

    public void Arcade2D()
    {
        SceneManager.LoadScene("2D Arcade");
    }

    public void ArcadeMenu()
    {
        SceneManager.LoadScene("ArcadeMenu");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
