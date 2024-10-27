using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    public float rotationSpeed = 20f; // Set rotation speed

    private void Update()
    {
        // Rotate the asteroid around its axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
