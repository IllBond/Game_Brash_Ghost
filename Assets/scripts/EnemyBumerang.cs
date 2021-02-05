using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBumerang : MonoBehaviour
{
    public float speed = -15f;
    private Rigidbody2D rb;
    private GameObject player;
    private bool isRotate = false;
    private Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }


    void Update() {
        run();
        if (isRotate == false && GetComponent<Transform>().position.x - player.GetComponent<Transform>().position.x < -8 && GetComponent<Transform>().position.x - player.GetComponent<Transform>().position.x > -14) {
            speed =15f;
            isRotate = true;
            anim.SetBool("Phase1", true);
        } else if (GetComponent<Transform>().position.x - player.GetComponent<Transform>().position.x < -14)
            {
            anim.SetBool("Phase2", true);
            speed = 50f;
        }
    }

    public void run() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            player.GetComponent<PlayerController>().Damage();
            Destroy(gameObject);
        }
    }
}
