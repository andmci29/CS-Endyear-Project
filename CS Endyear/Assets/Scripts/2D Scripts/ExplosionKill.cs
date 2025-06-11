using UnityEngine;
using System.Collections;

public class ExplosionKill : MonoBehaviour
{
    public GameObject self;
    void Start()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(1f);
        Destroy(self);
    }
}
