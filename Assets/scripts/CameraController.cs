using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moution;
    public Vector2 offset;
    private Transform player;
    public Vector3 startCamPosition;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(player.position.x - 30, transform.position.y + offset.y, transform.position.z);
    }

    void FixedUpdate() {
        if (moution < 20) {
            moution = moution * 1.01f;
        } 

        Vector3 target = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, moution * Time.deltaTime / 2);
        transform.position = currentPosition;
    }
}
