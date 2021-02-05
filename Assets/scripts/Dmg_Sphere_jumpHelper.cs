using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg_Sphere_jumpHelper : MonoBehaviour
{


    private GameObject playerObject;

    void Start() {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().Damage();
            Destroy(gameObject);
        }
    }
}
