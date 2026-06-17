
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpingPower = 4f;
    private bool isFacingRight = true;
    public float acceleration = 20f;
    public float deceleration = 10f;
    public float torqueForce = 10f;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            ;

        }



        Flip();
    }


    private void FixedUpdate()
    {

        rb.AddTorque(-horizontal * torqueForce);
        float targetSpeed = horizontal * speed;
        float speedDifference = targetSpeed - rb.linearVelocity.x;

        float accelRate = Mathf.Abs(targetSpeed) > 0.01f
            ? acceleration
            : deceleration;

        float movement = speedDifference * accelRate;

        rb.AddForce(Vector2.right * movement);

        // Clamp max speed
        rb.linearVelocity = new Vector2(
            Mathf.Clamp(rb.linearVelocity.x, -speed, speed),
            rb.linearVelocity.y
        );
    }



    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}