using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    private GameObject playerObject;

    private void Start() {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            playerObject.GetComponent<PlayerController>().Damage();
            Destroy(gameObject);
        }
    }
}



