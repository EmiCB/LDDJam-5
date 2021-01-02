using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum PlayerMovementMode {
        Horizonal,  // Default movement mode
        ClingingToWall,
        WallJumping,
    };

    private Rigidbody2D rigidbody2D = null;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 12.0f;
    [SerializeField] private float groundCheckRadius = 0.5f;

    [SerializeField] private int maxJumps = 1;
    [SerializeField] private int jumpCount = 0;

    [SerializeField] private float wallClingSlideSpeed = 0.7f;
    [SerializeField] private float wallJumpHorizSpeed = 3.0f;
    [SerializeField] private float wallJumpVertSpeed = 6.0f;
    [SerializeField] private float wallJumpDuration = 0.3f;
    private bool isClingingToWall = false;
    [SerializeField] private PlayerMovementMode movement = PlayerMovementMode.Horizonal;
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
            movement = PlayerMovementMode.Horizonal;
        }

        // End wall cling if no longer in contact
        if (movement == PlayerMovementMode.ClingingToWall && !CanClingToWall()) {
            movement = PlayerMovementMode.Horizonal;
        }
    }

    private void Update() {
        // wall clinging
        if (Input.GetKey(KeyCode.A) && !facingRight && CanClingToWall()) WallCling();
        if (Input.GetKey(KeyCode.D) && facingRight && CanClingToWall()) WallCling();

        // jumping
        if (Input.GetKeyDown(KeyCode.Space) && CanJump()) {
            if (movement == PlayerMovementMode.ClingingToWall) {
                BeginWallJumping();
            } else {
                Jump();
            }
        }

        // handle movement
        Move(Input.GetAxis("Horizontal"));
    }

    private Vector2 MoveVelocity(float input) {
        float wallJumpHoriz = facingRight ? -wallJumpHorizSpeed : wallJumpHorizSpeed;
        return movement switch {
            PlayerMovementMode.Horizonal        => new Vector2(input * speed, rigidbody2D.velocity.y),
            PlayerMovementMode.ClingingToWall   => new Vector2(input * speed, Input.GetAxis("Vertical") * -wallClingSlideSpeed),
            PlayerMovementMode.WallJumping      => new Vector2(wallJumpHoriz, wallJumpVertSpeed),
        };
    }

    private void Move(float input) {
        rigidbody2D.velocity = MoveVelocity(input);

        // flip sprite accordingly
        if (!facingRight && input > 0) FlipSprite();
        else if (facingRight && input < 0) FlipSprite();
    }

    private bool CanJump() {
        bool movementAllowed = movement switch {
            PlayerMovementMode.Horizonal        => true,
            PlayerMovementMode.ClingingToWall   => true,
            PlayerMovementMode.WallJumping      => false,
        }; 
        if (movementAllowed && jumpCount < maxJumps) {
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
        if (movement == PlayerMovementMode.WallJumping) {
            // if wall jump in progress, don't cling now
            return;
        }
        movement = PlayerMovementMode.ClingingToWall;
        jumpCount = 0;
    }

    private void BeginWallJumping() {
        Debug.Log("wall jump began");
        movement = PlayerMovementMode.WallJumping;
        jumpCount = 1;
        Invoke(nameof(EndWallJumping), wallJumpDuration);
    }
    private void EndWallJumping() {
        if (movement == PlayerMovementMode.WallJumping) {
            // if still wall jumping, return to normal movement
            movement = PlayerMovementMode.Horizonal;
        }
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