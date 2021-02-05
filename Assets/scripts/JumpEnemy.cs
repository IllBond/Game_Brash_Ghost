using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{

    private Rigidbody2D rb;
    //public GameObject img;
    private GameObject player;
    public int jumpForce = 25;
    public bool isJump = false;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GetComponent<Transform>().position.x - player.GetComponent<Transform>().position.x < 10 && player.GetComponent<PlayerController>().GetIsState() == "isJump" && isJump == false) {
            jump();
        }
    }

    public void jump() {
        rb.velocity = Vector2.up * jumpForce;
        isJump = true;
        anim.SetBool("IsJump", true);
        //смена картинки
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            anim.SetBool("IsJump", false);
        }
    }


}
