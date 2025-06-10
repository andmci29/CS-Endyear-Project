using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArcadeTie : MonoBehaviour
{
    [Header("Target Settings")]
    private Transform target;

    [Header("Position Settings")]
    public float frontOffset = 5f;
    public float approachSpeed = 1f; // How fast it gets closer to the player
    public float followDelay = 0.5f; // How smoothly it follows (lower = more delayed)

    [Header("Separation Settings")]
    public float separationDistance = 3f; // Minimum distance from other TIE Fighters
    public LayerMask tieFighterLayer = -1; // Layer mask for TIE Fighters

    [Header("Rotation Settings")]
    public float rotationSpeed = 5f;
    public bool lookAtTarget = true;

    [Header("Straight Line Settings")]
    public float straightLineSpeed = 10f; // Speed when moving in straight line past player
    public string sceneToLoad = "GameOver"; // Scene name to load
    public float sceneChangeDelay = 2f; // Delay before changing scene

    private float currentOffset;
    private bool isMovingStraight = false;
    private bool hasReachedPlayer = false;

    [Header("Other")]
    private GameObject tmpObject;
    private TextMeshProUGUI scoreText;
    public static int scoreDisplay = 0;

    void Start()
    {
        tmpObject = GameObject.FindGameObjectWithTag("Score");
        scoreText = tmpObject.GetComponent<TextMeshProUGUI>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Initialize current offset to the starting front offset
        currentOffset = frontOffset;
    }

    Vector3 ApplySeparation(Vector3 desiredPosition)
    {
        // Don't apply separation when moving in straight line
        if (isMovingStraight) return desiredPosition;

        // Find all nearby TIE Fighters
        Collider[] nearbyTies = Physics.OverlapSphere(transform.position, separationDistance, tieFighterLayer);

        Vector3 separationForce = Vector3.zero;
        int count = 0;

        foreach (Collider tie in nearbyTies)
        {
            // Skip self
            if (tie.gameObject == gameObject) continue;

            // Calculate direction away from other TIE Fighter
            Vector3 diff = transform.position - tie.transform.position;

            // Only apply vertical separation (Y axis)
            diff.x = 0; // Ignore horizontal separation
            diff.z = 0; // Ignore Z axis

            if (diff.magnitude < separationDistance && diff.magnitude > 0)
            {
                // Normalize and weight by distance (closer = stronger push)
                diff = diff.normalized / diff.magnitude;
                separationForce += diff;
                count++;
            }
        }

        if (count > 0)
        {
            separationForce /= count; // Average the forces
            separationForce *= separationDistance; // Scale the separation
            return desiredPosition + separationForce;
        }

        return desiredPosition;
    }

    void Update()
    {
        if (target == null) return;

        // Check if TIE Fighter has reached the same X position as the target
        if (!hasReachedPlayer && transform.position.x <= target.position.x)
        {
            hasReachedPlayer = true;
            isMovingStraight = true;

            scoreText.text = "A TIE got through!";

            // Start scene change countdown
            Invoke("ChangeScene", sceneChangeDelay);
        }

        if (isMovingStraight)
        {
            // Move in straight line to the left (past the player)
            transform.position += Vector3.left * straightLineSpeed * Time.deltaTime;
        }
        else
        {
            // Normal following behavior
            // Gradually reduce the offset to make the object get closer
            if (currentOffset > 0.5f) // Stop when very close
            {
                currentOffset -= approachSpeed * Time.deltaTime;
            }

            // Calculate desired position (in front of the target)
            Vector3 frontDirection = Vector3.right;
            Vector3 desiredPosition = target.position + (frontDirection * currentOffset);

            // Apply separation from other TIE Fighters
            desiredPosition = ApplySeparation(desiredPosition);

            // Smoothly move towards the desired position with delay
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followDelay * Time.deltaTime);
        }

        // Rotate to look at target if enabled (only when not moving straight)
        if (lookAtTarget && !isMovingStraight)
        {
            Vector3 directionToTarget = target.position - transform.position;

            // Only rotate on Z-axis (2D rotation)
            if (directionToTarget != Vector3.zero)
            {
                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            // Draw line to target
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);

            // Draw current desired position
            Vector3 desiredPos = target.position + (Vector3.right * currentOffset);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(desiredPos, 0.5f);

            // Draw original offset position for reference
            Vector3 originalPos = target.position + (Vector3.right * frontOffset);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(originalPos, 0.3f);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Blaster"))
        {
            scoreDisplay++;
            scoreText.text = "TIEs Blasted: " + scoreDisplay.ToString();

            Destroy(gameObject); // Use gameObject instead of self
            Destroy(coll.gameObject);
        }
    }
}
