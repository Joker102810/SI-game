using UnityEngine;

public class OldPM : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 5f;
    private bool isFacingRight = true;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float momentum = 5f;

    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float deceleration = 25f;

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
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        float targetVelocityX = horizontal * speed;

        rb.linearVelocity = new Vector2(
            Mathf.Lerp(rb.linearVelocity.x, targetVelocityX, momentum * Time.fixedDeltaTime),
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