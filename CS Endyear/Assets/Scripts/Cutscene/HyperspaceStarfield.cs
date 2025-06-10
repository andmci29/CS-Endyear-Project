using UnityEngine;
using System.Collections.Generic;

public class HyperspaceStarField : MonoBehaviour
{
    [Header("Star Generation")]
    public int starCount = 500;
    public float starFieldRadius = 100f;
    public Material starMaterial;

    [Header("Hyperspace Effect")]
    [Range(0f, 1f)]
    public float hyperspaceProgress = 0f;
    public float maxStretchLength = 20f;
    public float jumpSpeed = 5f;

    [Header("Visual Settings")]
    public Color starColorMin = Color.white;
    public Color starColorMax = Color.blue;
    public float starSize = 0.1f;
    public float brightnessMultiplier = 2f;

    private List<Star> stars = new List<Star>();
    private LineRenderer[] lineRenderers;
    private bool isJumping = false;

    [System.Serializable]
    public class Star
    {
        public Vector3 position;
        public Vector3 direction;
        public float brightness;
        public Color color;

        public Star(Vector3 pos, float bright)
        {
            position = pos;
            direction = pos.normalized;
            brightness = bright;
            color = Color.white;
        }
    }

    void Start()
    {
        GenerateStars();
        CreateLineRenderers();
    }

    void GenerateStars()
    {
        stars.Clear();

        for (int i = 0; i < starCount; i++)
        {
            // Generate stars on a flat wall/plane in front of origin
            float x = Random.Range(-starFieldRadius, starFieldRadius);
            float y = Random.Range(-starFieldRadius, starFieldRadius);
            float z = Random.Range(5f, starFieldRadius); // Start at minimum distance of 5 units forward

            Vector3 randomPos = new Vector3(x, y, z);

            float brightness = Random.Range(0.3f, 1f);

            // Generate random color between starColorMin and starColorMax
            Color randomColor = Color.Lerp(starColorMin, starColorMax, Random.Range(0f, 1f));

            Star star = new Star(randomPos, brightness);
            star.color = randomColor;
            stars.Add(star);
        }
    }

    void CreateLineRenderers()
    {
        // Create a parent object to hold all line renderers
        GameObject lineParent = new GameObject("StarLines");
        lineParent.transform.SetParent(transform);

        lineRenderers = new LineRenderer[starCount];

        for (int i = 0; i < starCount; i++)
        {
            GameObject lineObj = new GameObject($"StarLine_{i}");
            lineObj.transform.SetParent(lineParent.transform);

            LineRenderer lr = lineObj.AddComponent<LineRenderer>();
            lr.material = starMaterial;
            lr.startWidth = starSize;
            lr.endWidth = starSize * 0.1f;
            lr.positionCount = 2;
            lr.useWorldSpace = true;
            lr.enabled = false;

            lineRenderers[i] = lr;
        }
    }

    void Update()
    {
        UpdateStarEffect();
    }

    void UpdateStarEffect()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            Star star = stars[i];
            LineRenderer lr = lineRenderers[i];

            if (hyperspaceProgress <= 0f)
            {
                // Show as points (disable line renderer)
                lr.enabled = false;
            }
            else
            {
                // Show as stretched lines
                lr.enabled = true;

                // Calculate stretch length based on hyperspace progress
                float stretchLength = hyperspaceProgress * maxStretchLength;

                // Start position (current star position)
                Vector3 startPos = star.position;

                // End position (stretched along direction away from center)
                Vector3 endPos = startPos + (star.direction * stretchLength);

                // Set line positions
                lr.SetPosition(0, startPos);
                lr.SetPosition(1, endPos);

                // Update color and brightness using the star's individual color
                Color currentColor = star.color * star.brightness * brightnessMultiplier;
                currentColor.a = Mathf.Lerp(1f, 0.5f, hyperspaceProgress);

                lr.startColor = currentColor;
                lr.endColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);

                // Optionally move stars during hyperspace
                if (isJumping)
                {
                    star.position += star.direction * jumpSpeed * Time.deltaTime;
                }
            }
        }
    }


    public void StartHyperspaceJump()
    {
        StartCoroutine(HyperspaceSequence());
    }

    private System.Collections.IEnumerator HyperspaceSequence()
    {
        isJumping = true;
        float duration = 3f; // Total jump duration
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            // Ease-in-out curve for smooth acceleration
            float t = elapsed / duration;
            hyperspaceProgress = Mathf.SmoothStep(0f, 1f, t);

            yield return null;
        }

        hyperspaceProgress = 1f;

        // Optional: Reset after jump completes
        yield return new WaitForSeconds(1f);
        ResetStarField();
    }

    public void ResetStarField()
    {
        isJumping = false;
        hyperspaceProgress = 0f;
        GenerateStars(); // Regenerate stars for next jump
    }

    // Manual control for testing
    public void SetHyperspaceProgress(float progress)
    {
        hyperspaceProgress = Mathf.Clamp01(progress);
    }

    void OnDrawGizmosSelected()
    {
        // Draw star field radius in scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, starFieldRadius);
    }
}