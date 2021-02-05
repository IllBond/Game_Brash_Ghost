using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class oldCameraController : MonoBehaviour
{
    public float moution; //плавное движение камеры
    public Vector2 offsetBottom;
    public Vector2 offsetCenter;
    public Vector2 offsetTop;
    public int isTop;
    private Transform player;
    public bool moutionCam = true;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(player.position.x + offsetTop.x, player.position.y + 2, transform.position.z);
    }

    public void turnUp(int state)
    {
        isTop = state;
    }

    void FixedUpdate()
    {
        if (isTop == 1)
        {
            Vector3 target = new Vector3(player.position.x + offsetBottom.x, player.position.y + offsetBottom.y, transform.position.z);
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, moution * Time.deltaTime / 2);
            if (moutionCam)
            {
                transform.position = currentPosition;

            }
            else
            {
                transform.position = target;
            }
        }
        else if (isTop == 2)
        {
            Vector3 target = new Vector3(player.position.x + offsetCenter.x, player.position.y + offsetCenter.y, transform.position.z);
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, moution * Time.deltaTime / 2);
            if (moutionCam)
            {

                transform.position = currentPosition;
            }
            else
            {
                transform.position = target;
            }
        }
        else
        {
            Vector3 target = new Vector3(player.position.x + offsetTop.x, player.position.y + offsetTop.y, transform.position.z);
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, moution * Time.deltaTime / 2);
            if (moutionCam)
            {

                transform.position = currentPosition;
            }
            else
            {
                transform.position = target;
            }
        }


    }
}
