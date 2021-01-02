using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 1.5f;

    public bool isPlayerInRange = false;

    // call from within base class, meant to be overwritten
    public virtual void Interact() {
        Debug.Log("Interacting with " + gameObject.name);
    }


    void Update() {
        if (isPlayerInRange) {
            Interact();
        }
    }

    void FixedUpdate() {
        // sets a flag if player is in range of object
        isPlayerInRange = CheckForPlayer();
    }


    private bool CheckForPlayer() {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D collision in collisions) {
            if(collision.tag == "Player") {
                return true;
            }
        }
        return false;
    }


    // for testing
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

