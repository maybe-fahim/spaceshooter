using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Destroy the root parent of the object that enters the boundary trigger
        Destroy(other.transform.root.gameObject);
    }
}
