using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthDecrease : MonoBehaviour
{
    public Image healthbar;

    void Update()
    {
        if (healthbar.transform.localScale.x == 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Obstacle"))
        {
            healthbar.transform.localScale = new Vector3(healthbar.transform.localScale.x - 3f, 1f, 1f);
            Destroy(coll.gameObject);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
