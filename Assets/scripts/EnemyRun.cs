using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    private float speed = -25f; // Скорость перемешения
    private Rigidbody2D rb;
    private GameObject playerObject;

    void Start()  {
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Destroy(gameObject);
            playerObject.GetComponent<PlayerController>().Damage();
        }
    }
}
