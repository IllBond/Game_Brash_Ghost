using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesRaner : MonoBehaviour
{

    private Rigidbody2D rb;

    public float coor;
    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update() {

        rb.velocity = new Vector2(speed, rb.velocity.y);


        if (transform.position.y < coor) {
            rb.gravityScale = -2;
        } else if (transform.position.y > coor) {
            rb.gravityScale = 2;
        }

    }
}
