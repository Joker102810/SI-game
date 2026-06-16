using TMPro;
using UnityEngine;

public class CDetection : MonoBehaviour
{

    public bool colliding;
    Rigidbody2D rb;
    public BoxCollider2D box;
    public float xvalue;
    public Vector2 targetPosition;
    public float speed = 5f;
    public Vector2 currentPosition;

    void Start()
    {
        colliding = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }
}
