using UnityEngine;

public class StarSpawn2D : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 50f;

    void Start()
    {
        ParticleSystem stars = GetComponent<ParticleSystem>();

        var main = stars.main;
        main.startLifetime = 10f;
        main.startSpeed = 5f;
        main.startSize = 0.1f;
        main.startColor = Color.white;
        main.maxParticles = 1000;

        var emission = stars.emission;
        emission.rateOverTime = 75f;

        var shape = stars.shape;
        shape.enabled = true;
        shape.shapeType = ParticleSystemShapeType.Circle;
        shape.radius = 90f;

        var velocityOverLifetime = stars.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        velocityOverLifetime.space = ParticleSystemSimulationSpace.Local;
        velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(-15f);

        var renderer = stars.GetComponent<ParticleSystemRenderer>();

        var colorOverLifetime = stars.colorOverLifetime;
        colorOverLifetime.enabled = true;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
        );
        colorOverLifetime.color = gradient;
    }

    void Update()
    {
        Vector3 playerPosition = new Vector3(player.position.x, 0, 0);
        if (player != null)
        {
            transform.position = playerPosition + Vector3.right * distanceFromPlayer;
        }
    }
}