using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the movement speed
    public float jumpForce = 10f; // Adjust the jump force
    public int maxJumps = 2; // Set the maximum number of jumps (including the initial jump)

    private Rigidbody2D rb2d;
    private int jumpsRemaining; // Keep track of remaining jumps
    private bool isGrounded; // Flag to track if the character is grounded
    private Animator animator; // Reference to the character's Animator component

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);

        // Get input for horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Move the character horizontally
        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);

        // Flip the character based on movement direction
        if (moveHorizontal != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveHorizontal), 1, 1);

        // Set animation parameters
        animator.SetBool("IsMoving", Mathf.Abs(moveHorizontal) > 0);
        animator.SetBool("IsJumping", !isGrounded);

        // Check if the Jump button is pressed
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
            Jump();
    }

    private void Jump()
    {
        // Apply an upward force for jumping
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        jumpsRemaining--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character collides with the ground (you can adjust the ground layer)
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
            ResetJumps();
        }
    }

    // Call this method to reset jumps (e.g., when grounded)
    private void ResetJumps()
    {
        jumpsRemaining = maxJumps;
    }
}
