using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 5f;
    
    private void Update()
    {
        // Move the asteroid forward
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
