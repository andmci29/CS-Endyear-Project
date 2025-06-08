using UnityEngine;

public class sphereFollow : MonoBehaviour
{
    public GameObject sphere;

    // Update is called once per frame
    void Update()
    {
        transform.position = sphere.transform.position;
        transform.rotation = sphere.transform.rotation;
    }
}
