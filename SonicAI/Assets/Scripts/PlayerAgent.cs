using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PlayerAgent : Agent
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    public Collider2D boundaryCollider;
    public PlayerHealth health;
    public SonicController controller;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float crouchSpeedMultiplier = 0.5f;
    private float previousScore = 0f;


    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isCrouching = false;
    public Animator animator;
    private Vector2 originalColliderSize;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        originalColliderSize = playerCollider.bounds.size;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.x);
        sensor.AddObservation(transform.position.y);
        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.y);

        sensor.AddObservation(isGrounded ? 1.0f : 0.0f);

        sensor.AddObservation(health.ringCount);

        RaycastHit2D obstacleHit = Physics2D.Raycast(transform.position, Vector2.right, 1f, groundLayer);
        sensor.AddObservation(obstacleHit.collider != null ? 1.0f : 0.0f);

        RaycastHit2D groundHit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.down, 2f, groundLayer);
        sensor.AddObservation(groundHit.collider != null ? groundHit.distance : -1.0f);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        float moveY = Mathf.Clamp(actions.ContinuousActions[1], -1f, 1f);

        bool obstacleDetected = CheckForObstacleAhead();

        bool jump = actions.DiscreteActions[0] == 1 || obstacleDetected; 
        bool crouch = actions.DiscreteActions[1] == 1;

        if (crouch && isGrounded)
        {
            isCrouching = true;
            animator.SetBool("IsCrouching", true);
            rb.velocity = new Vector2(moveX * moveSpeed * crouchSpeedMultiplier, rb.velocity.y);
        }
        else
        {
            isCrouching = false;
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        }

        if (jump && isGrounded)
        {
            isCrouching = false;
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (jump && obstacleDetected)
        {
            AddReward(0.5f); // Reward for jumping over obstacle
        }

        if (!isGrounded && rb.velocity.y < 0)
        {
            RaycastHit2D groundHit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.down, 2f, groundLayer);
            if (groundHit.collider == null)
            {
                AddReward(-1.0f);  // Penalize for falling into a gap
                EndEpisode();
            }
        }

        if (controller.isAlive == false)
        {
            AddReward(-10.0f);
            EndEpisode();
        }

        // Scoring logic
        float currentScore = health.finalScore;
        float scoreDifference = currentScore - previousScore;
        if (scoreDifference > 0)
        {
            AddReward(scoreDifference);
        }
        else if (scoreDifference < 0)
        {
            AddReward(scoreDifference * 0.5f); 
        }

        previousScore = currentScore;

        if (Mathf.Abs(rb.velocity.x) < 0.2f && Mathf.Abs(rb.velocity.y) < 0.2f)
        {
            AddReward(-1f);
        }

        if (ReachedGoal())
        {
            AddReward(10.0f);
            EndEpisode();
        }

        if (TouchBoundary(boundaryCollider))
        {
            AddReward(-0.5f);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        var discreteActions = actionsOut.DiscreteActions;

        continuousActions[0] = Input.GetAxis("Horizontal");
        continuousActions[1] = Input.GetAxis("Vertical");   
        discreteActions[0] = Input.GetKey(KeyCode.Space) ? 1 : 0; 
        discreteActions[1] = Input.GetKey(KeyCode.DownArrow) ? 1 : 0; 
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    public bool ReachedGoal()
    {
        if (controller.win)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool TouchBoundary(Collider2D collider)
    {
        if (collider.CompareTag("Boundary"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckForObstacleAhead()
    {
        RaycastHit2D obstacleHit = Physics2D.Raycast(transform.position, Vector2.right, 1f, groundLayer);
        return obstacleHit.collider != null;
    }
}
