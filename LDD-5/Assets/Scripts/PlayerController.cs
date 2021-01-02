using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rigidbody2D = null;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float groundCheckRadius = 0.5f;

    [SerializeField] private int maxJumps = 1;
    [SerializeField] private int jumpCount = 0;

    private bool facingRight = true;
    public bool isDead = false;

    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask ground;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // runs every phsyics update
    private void FixedUpdate() {
        // check grounded w/ projected circle at bottom of player
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground)) {
            jumpCount = 0;
        }

        // handle inputs
        Move(Input.GetAxis("Horizontal"));
    }

    private void Update() {
        // jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump()) Jump();
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

    private void Jump() {
        rigidbody2D.velocity = Vector2.up * jumpForce;
        jumpCount++;
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