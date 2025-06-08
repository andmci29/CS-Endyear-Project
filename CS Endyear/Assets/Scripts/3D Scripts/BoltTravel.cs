using UnityEngine;

public class BoltTravel : MonoBehaviour
{
    private Vector3 direction;
    private Transform target;

    public float speed = 1.0f;
    public GameObject self;

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }


    void Start()
    {
        direction = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        Vector3 movement = new Vector3(transform.position.x, transform.position.y, target.position.z);
        transform.position = movement;
        transform.forward = target.up;
        CheckKill();
    }

    void CheckKill()
    {
        if (transform.position.z < -165.0f || transform.position.x > 170 || transform.position.x < -170)
        {
            Destroy(self);
        }
    }
}
