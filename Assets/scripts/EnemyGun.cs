using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private float speed = 15f; // Скорость перемешения
    private Rigidbody2D rb;
    private Coroutine showSphere;
    public GameObject sph;
    private GameObject player;
    private int guns = 7;
    

    void Start()  {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        showSphere = StartCoroutine(showSphereFunc());
    }

    IEnumerator showSphereFunc() {
        while (true)  {
            SpawnSphere();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnSphere() {
        if (guns <= 0) {
            StopCoroutine(showSphere);
        }
        if (guns !=0) {
            GameObject sphere = Instantiate(
                sph,
                new Vector3(GetComponent<Transform>().position.x - 2, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z),
                Quaternion.identity);
            guns--;
            if (player.transform.position.x - GetComponent<Transform>().position.x <= 0)
            {
                sphere.GetComponent<Rigidbody2D>().velocity = new Vector2(
                (player.transform.position.x - GetComponent<Transform>().position.x) / 2,
                (player.transform.position.y - GetComponent<Transform>().position.y) / 2);
            }
            Destroy(sphere, 15f);
        }
    }

    void Update() {
        rb.velocity = new Vector2(speed, rb.velocity.y);


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("EnemyGunSph"))
        {
            guns = 0;
        }
    }
}
