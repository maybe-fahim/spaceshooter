using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float speed = 20f;  // Adjust this for the speed of the bolt

    private void Update()
    {
        // Move the bolt forward along the Z-axis in local space
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
