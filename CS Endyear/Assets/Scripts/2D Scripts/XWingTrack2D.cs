using UnityEngine;

public class XWingTrack2D : MonoBehaviour
{
    public GameObject sphere;

    // Update is called once per frame
    void Update()
    {
        transform.position = sphere.transform.position;
        transform.rotation = Quaternion.Euler(sphere.transform.rotation.x * 300, -90f, sphere.transform.rotation.z);
    }
}
