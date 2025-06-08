using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    void Start()
    {
        ParticleSystem stars = GetComponent<ParticleSystem>();

        var main = stars.main;
        main.startLifetime = 15f;
        main.startSpeed = 5f;
        main.startSize = 0.1f;
        main.startColor = Color.white;
        main.maxParticles = 1000;
        main.prewarm = true;

        var emission = stars.emission;
        emission.rateOverTime = 75f;

        var shape = stars.shape;
        shape.enabled = true;
        shape.shapeType = ParticleSystemShapeType.Circle;
        shape.radius = 90f;
        shape.position = new Vector3(0, 0, 50f);

        var velocityOverLifetime = stars.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        velocityOverLifetime.space = ParticleSystemSimulationSpace.Local;
        velocityOverLifetime.z = new ParticleSystem.MinMaxCurve(-15f);

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
}