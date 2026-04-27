using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerGravityMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float accel = 12f;
    [SerializeField] float decel = 16f;
    [SerializeField] float jumpImpulse = 7f;
    [SerializeField] int maxJumps = 2;
    int jumpsLeft;

    [SerializeField] int score = 0;

    Vector2 currentVelocity;
    Rigidbody2D rb;
    Vector2 startPos;

    float moveX;
    bool jumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            jumpPressed = true;
            jumpsLeft--;
        }
    }
    void Start()
    {
        startPos = rb.position;
    }

    void FixedUpdate()
    {
        float targetX = moveX * maxSpeed;
        float rate = (Mathf.Abs(moveX) > 0f) ? accel : decel;

        currentVelocity.x = Mathf.MoveTowards(
            currentVelocity.x,
            targetX,
            rate * Time.fixedDeltaTime
        );

        currentVelocity.y = rb.velocity.y;

        rb.velocity = currentVelocity;

        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
            jumpPressed = false;
        }
    }

    public void Respawn()
    {
        rb.position = startPos;
        rb.velocity = Vector2.zero;
        currentVelocity = Vector2.zero;
        jumpsLeft = maxJumps;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpsLeft = maxJumps;

        if (collision.collider.CompareTag("Wall"))
        {
            Respawn();
            Debug.Log("Hit Wall! Restart!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        TargetInteractables target = other.GetComponent<TargetInteractables>();
        if (target != null)
        {
            score += 1;
            target.Trigger();
            Debug.Log("Picked up! Score = " + score);

        }
    }
}
