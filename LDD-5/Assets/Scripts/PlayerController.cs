using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rigidbody2D = null;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 12.0f;
    [SerializeField] private float groundCheckRadius = 0.5f;

    [SerializeField] private int maxJumps = 1;
    [SerializeField] private int jumpCount = 0;

    [SerializeField] private float wallClingSlideSpeed = 0.3f;
    [SerializeField] private float wallJumpHorizSpeed = 3.0f;
    [SerializeField] private float wallJumpVertSpeed = 6.0f;
    [SerializeField] private float wallJumpDuration = 0.3f;
    [SerializeField] private bool isClingingToWall = false;
    [SerializeField] private bool isWallJumping = false;

    [SerializeField] private bool facingRight = true;
    public bool isDead = false;

    private Collider2D cldr;

    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask wall;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        cldr = GetComponent<Collider2D>();
    }

    private void FixedUpdate() {
        // check grounded w/ projected circle at bottom of player
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground)) {
            jumpCount = 0;
            isClingingToWall = false;
        }
        if (!CanClingToWall()) {
            isClingingToWall = false;
        }
    }

    private void Update() {
        // handle inputs
        Move(Input.GetAxis("Horizontal"));

        // wall clinging
        if (Input.GetKey(KeyCode.A) && !facingRight && CanClingToWall()) WallCling();
        if (Input.GetKey(KeyCode.D) && facingRight && CanClingToWall()) WallCling();

        // jumping
        if (Input.GetKeyDown(KeyCode.Space) && CanJump()) {
            if (isClingingToWall) {
                BeginWallJumping();
            } else {
                Jump();
            }
        }

        if (isWallJumping) {
            // Jump away from wall
            float x = facingRight ? -wallJumpHorizSpeed : wallJumpHorizSpeed;
            rigidbody2D.velocity =  new Vector2(x, wallJumpVertSpeed);
        }
    }

    private Vector2 MoveVelocity(float input) {
        if (isClingingToWall) {
            return new Vector2(input * speed, Input.GetAxis("Vertical") * -wallClingSlideSpeed);
        }
        return new Vector2(input * speed, rigidbody2D.velocity.y);
    }

    private void Move(float input) {
        rigidbody2D.velocity = new Vector2(input * speed, rigidbody2D.velocity.y);

        // flip sprite accordingly
        if (!facingRight && input > 0) FlipSprite();
        else if (facingRight && input < 0) FlipSprite();
    }

    private bool CanJump() {
        if (jumpCount < maxJumps) {
            return true;
        } else {
            return false;
        }
    }
    private bool CanClingToWall() {
        bool isMovingVertically = Mathf.Abs(rigidbody2D.velocity.y) > float.Epsilon;
        bool isTouchingWall = Physics2D.IsTouchingLayers(cldr, wall);
        return isTouchingWall && isMovingVertically;
    }

    private void Jump() {
        rigidbody2D.velocity = Vector2.up * jumpForce;
        jumpCount++;
    }

    private void WallCling() {
        isClingingToWall = true;
        jumpCount = 0;

        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Clamp(rigidbody2D.velocity.y, -wallClingSlideSpeed, float.MaxValue));
    }

    private void BeginWallJumping() {
        Debug.Log("wall jump began");
        isWallJumping = true;
        isClingingToWall = false;
        jumpCount = 1;
        Invoke(nameof(EndWallJumping), wallJumpDuration);
    }
    private void EndWallJumping() {
        isWallJumping = false;
    }

    private void FlipSprite() {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Killbox") isDead = true;
    }
}