using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    public float fadeDuration = 2f; // How long the fade takes
    private Image fadeImage;

    void Start()
    {
        // Get the Image component from this GameObject
        fadeImage = GetComponent<Image>();
        fadeImage.enabled = true;

        // Start with black screen, then fade to transparent
        FadeFromBlack();
    }

    void FadeFromBlack()
    {
        // Make sure image starts completely black
        fadeImage.color = Color.black;

        // Fade to transparent over time
        StartCoroutine(FadeCoroutine());
    }

    System.Collections.IEnumerator FadeCoroutine()
    {
        float elapsedTime = 0f;
        Color startColor = Color.black; // Start opaque black
        Color endColor = new Color(0, 0, 0, 0); // End transparent

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            // Lerp between black and transparent
            fadeImage.color = Color.Lerp(startColor, endColor, t);

            yield return null; // Wait one frame
        }

        // Make sure it's completely transparent at the end
        fadeImage.color = endColor;
        fadeImage.enabled = false;
    }
}