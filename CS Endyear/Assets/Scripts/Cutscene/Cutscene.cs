using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Cutscene : MonoBehaviour
{
    public HyperspaceStarField stars;

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        yield return new WaitForSeconds(1f);
        stars.StartHyperspaceJump();

        yield return new WaitForSeconds(5.5f);

        SceneTransition.LoadTarget();
    }
}
