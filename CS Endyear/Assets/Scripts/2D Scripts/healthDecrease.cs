using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class healthDecrease : MonoBehaviour
{
    public Image healthbar;
    public GameObject explosion;

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
        if (coll.collider.CompareTag("Mine"))
        {
            Destroy(coll.gameObject);
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        healthbar.transform.localScale = new Vector3(0f, 1f, 1f);

    }
}
