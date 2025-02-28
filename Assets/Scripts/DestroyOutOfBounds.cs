using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float leftBound = -12f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound) {

            Destroy(gameObject);
        }
    }
}
