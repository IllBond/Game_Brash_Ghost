using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_GenerationNewBack : MonoBehaviour
{

    public float backgroundSize;
    private Transform CameraTransform;
    public Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;


    void Start()
    {
        CameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;

    }


    void Update()
    {
        if (CameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) {
            ScrollLeft();
        }

        if (CameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone)) {
            ScrollRight();
        }
    }

    private void ScrollLeft() {
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0) {
            rightIndex = layers.Length - 1;
        }
    }

    //Convert.ToInt32(Math.Round(
    //Math.Round(
    private void ScrollRight() {
        Vector3 x = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        layers[leftIndex].position = x;
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length) {
            leftIndex = 0;
        }
    }
}
