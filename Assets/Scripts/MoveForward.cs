using UnityEngine;
using UnityEngine.UIElements;

public class MoveForward : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
