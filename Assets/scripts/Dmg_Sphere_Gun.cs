using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg_Sphere_Gun : MonoBehaviour
{

    private GameObject playerObject;
    private int rebound1;
    private int rebound2;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().Damage();
            Destroy(gameObject);
        }

        if (collision.tag.Equals("EnemyGun"))
        {
            rebound1 = Random.Range(-5, 5);
            rebound2 = Random.Range(0, 3);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(rebound1, rebound2);
            gameObject.transform.localScale = new Vector3(4, 4, 4);
        }

    }
}
