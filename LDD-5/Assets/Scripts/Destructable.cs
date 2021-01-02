using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    private PlayerController player;
    
    private bool hasFastDropped = false;
    private Vector2 currentPosition;
    private Vector2 currentSize;
    private Vector2 boxPosition;

    [SerializeField] private LayerMask playerLayer;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentPosition = this.gameObject.transform.position;
        currentSize = this.gameObject.transform.localScale;
        boxPosition = new Vector2(currentPosition.x, currentPosition.y + 1.0f);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        float yVelocity = col.relativeVelocity.y;
        bool hasFastDropped = Mathf.Abs(yVelocity) >= Mathf.Abs(player.fastDropVertSpeed) &&  yVelocity < 0;
        if (col.gameObject.tag == "Player" && hasFastDropped) {
            Debug.Log("Platform Broken!");
            this.gameObject.SetActive(false);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxPosition, currentSize);
    }
}
