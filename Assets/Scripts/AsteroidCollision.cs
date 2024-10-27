using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt")) // Assuming bolts are tagged as "Bolt"
        {
            Destroy(other.gameObject); // Destroy the bolt
            Destroy(gameObject);       // Destroy the asteroid
        }
    }
}
