using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
