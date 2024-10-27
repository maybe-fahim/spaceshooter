using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    public float speed = 10f;
    public float tiltAngle = 15f; // Maximum tilt angle on the Z-axis
    public GameObject boltPrefab; // Reference to the Bolt prefab
    public Transform firePoint;   // Reference to the FirePoint position
    public float fireRate = 0.5f; // Minimum time between shots

    private Rigidbody rb;
    private float nextFireTime = 0f; // Tracks the time when the player can shoot next

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get the movement input from InputManager
        Vector2 input = InputManager.instance.moveAction.ReadValue<Vector2>();

        // Calculate movement vector and apply speed
        Vector3 movement = new Vector3(input.x, 0, input.y) * speed;

        // Move the ship by setting velocity directly
        rb.velocity = movement;

        // Restrict the ship within screen bounds
        float clampedX = Mathf.Clamp(rb.position.x, -8f, 8f); // Set X limits
        float clampedZ = Mathf.Clamp(rb.position.z, -4f, 4f); // Set Z limits
        rb.position = new Vector3(clampedX, rb.position.y, clampedZ);

        // Rotate the ship based on horizontal input for a tilting effect
        float rotationZ = -input.x * tiltAngle; // Invert X for a more intuitive tilt
        rb.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void Update()
    {
        // Check if the Fire action is triggered and the cooldown period has passed
        if (InputManager.instance.fireAction.triggered && Time.time >= nextFireTime)
        {
            ShootBolt();
            nextFireTime = Time.time + fireRate; // Update the next allowable fire time
        }
    }

    private void ShootBolt()
    {
        // Instantiate the bolt at the FirePoint's position and rotation
        Instantiate(boltPrefab, firePoint.position, firePoint.rotation);
    }
}
