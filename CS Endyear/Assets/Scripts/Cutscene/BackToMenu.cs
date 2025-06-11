using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMenu : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(ToMenu());
    }

    IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(36f);
        SceneManager.LoadScene("Menu");
    }
}
