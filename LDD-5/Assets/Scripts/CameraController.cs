using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMoveX;
    private float distanceToMoveY;
    [SerializeField] private float yThreshold = 3.0f;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
    }

    private void Update() {
        distanceToMoveX = player.transform.position.x - lastPlayerPosition.x;
        distanceToMoveY = Mathf.Abs(player.transform.position.y - this.transform.position.y) > yThreshold ? player.transform.position.y - lastPlayerPosition.y : 0;
        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y + distanceToMoveY, transform.position.z);
        lastPlayerPosition = player.transform.position;
    }
}