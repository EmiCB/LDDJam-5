using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMoveX;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
    }

    private void Update() {
        distanceToMoveX = player.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y, transform.position.z);
        lastPlayerPosition = player.transform.position;
    }
}