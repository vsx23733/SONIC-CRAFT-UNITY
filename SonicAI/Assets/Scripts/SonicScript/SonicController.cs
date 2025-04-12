using UnityEngine;

public class SonicController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float Speed = 8f;
    public float acceleration = 20f;
    public float deceleration = 30f;
    public float jumpForce = 15f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Health Manager")]
    public PlayerHealth healthManager;

    [Header("Score")]
    private float scoreForWinningLevel = 1000000000000f;

    private float horizontalInput;

    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    //private bool IsAccelerating = false;
    public bool win = false;
    public bool isAlive = true;

    // Speed threshold values (tweak these to suit your game)

    //[Header("Acceleration Settings")]
    //public float runThreshold = 1f;
    //public float accelerationThreshold = 10f;

    // "Controling the UI"
    //private UIManager GameUIManager;



    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        float speed = Mathf.Abs(rb.velocity.x);
        float smoothSpeed = Mathf.Lerp(rb.velocity.x, speed, Time.deltaTime * acceleration);
        animator.SetFloat("Sonic_Speed", speed);

        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            animator.SetBool("IsCrouching", false);
        }

        // Handling Acceleration
        //if (speed > accelerationThreshold)
        //{
        //    animator.SetBool("IsAccelerating", true);
        //}
        //else
        //{
        //    animator.SetBool("IsAccelerating", false);
        //}
        // Debug.Log($"Speed: {rb.velocity.x}, Jumping: {!isGrounded}, Crouching: {Input.GetKey(KeyCode.DownArrow)}");



    }

    void FixedUpdate()
    {
        float targetSpeed = horizontalInput * Speed;
        float speedDifference = targetSpeed - rb.velocity.x;
        float accelerationRate = (Mathf.Abs(targetSpeed) > 0.1f) ? acceleration : deceleration;
        float movement = speedDifference * accelerationRate * Time.fixedDeltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);
        rb.velocity = new Vector2(rb.velocity.x + movement, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ControlPanel"))
        {
            healthManager.finalScore += scoreForWinningLevel;
            win = true;
            EndGame();
        }
        else
        {
            if (other.CompareTag("Boundary"))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    void EndGame()
    {
        Debug.Log("Level Completed! Sonic reached the Goal Post");
        // win = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}