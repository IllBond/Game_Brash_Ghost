using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudIsTriger : MonoBehaviour
{
    private GameObject player;
    private Collider2D box;

    void Start() {
        box = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update() {
        if (player.GetComponent<Transform>().position.y < GetComponent<Transform>().position.y + 0.5f) {
            box.isTrigger = true;
            if (player.GetComponent<Transform>().position.x > GetComponent<Transform>().position.x - 1.2f && 
                player.GetComponent<Transform>().position.x < GetComponent<Transform>().position.x + 1.2f) {
                box.isTrigger = true;
               // player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 0.5f, player.GetComponent<Transform>().position.z);
            }
        } else {
        box.isTrigger = false;
        }
    }
}
