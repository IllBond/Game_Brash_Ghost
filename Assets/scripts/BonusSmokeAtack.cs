using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSmokeAtack : MonoBehaviour
{
    private GameObject playerObject;
    public GameObject smoke;
    private float coorX;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        coorX = transform.position.x;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        coorX = transform.position.x;

        if (collision.tag.Equals("Player"))
        {
                GameObject effect = Instantiate(
                    smoke,
                    new Vector3(coorX + 150 + Random.Range(0, 25), 10, -10),
                    Quaternion.identity);
                Destroy(effect, 30f);
            Destroy(gameObject);
        }
    }
}
