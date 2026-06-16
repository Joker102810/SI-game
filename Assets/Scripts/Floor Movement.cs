using TMPro;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{

    public bool colliding;
    Rigidbody2D rb;
    public float xvalue;
    public Vector2 targetPosition;
    public float speed = 5f;

    void Start()
    {
        colliding = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

    // Update is called once per frame
    void Update()
    {/*
        if (colliding == true)
        {

            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));

        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            colliding = true;
            //rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));

        }

        if (colliding)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));
            //colliding = false;
        }

        Debug.Log(colliding);
    }
}
