using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_Paralax : MonoBehaviour
{
    private Transform CameraTransform;
    public float paralaxspeed;
    private float lastCameraX;

    void Start() {
        CameraTransform = Camera.main.transform;
        lastCameraX = CameraTransform.position.x;

    }

    void FixedUpdate()  {
        float deltaX = CameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * paralaxspeed);
        lastCameraX = CameraTransform.position.x;
    }
}
