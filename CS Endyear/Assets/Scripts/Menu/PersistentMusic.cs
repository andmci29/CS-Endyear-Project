using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    private static PersistentMusic instance;

    void Awake()
    {
        // If an instance already exists, destroy this one
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Make this the only instance and mark it as persistent
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}