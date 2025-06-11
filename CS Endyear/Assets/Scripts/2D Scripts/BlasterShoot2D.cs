using UnityEngine;

public class BlasterShoot2D : MonoBehaviour
{
    public GameObject bolt;
    public AudioSource blasterSound;

    void Start()
    {
        blasterSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Spawn(bolt);
            blasterSound.Play();
        }
    }

    void Spawn(GameObject obstacle)
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        Vector3 spawnPosition = new Vector3(x, y, z);
        Quaternion rotation = Quaternion.Euler(-transform.rotation.x * 300, 90f, 90f);
        GameObject bolt = Instantiate(obstacle, spawnPosition, rotation);
    }
}
