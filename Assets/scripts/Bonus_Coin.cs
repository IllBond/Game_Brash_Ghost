using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus_Coin : MonoBehaviour
{
    private GameObject playerObject;

    private void Start() {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

/*    public void OnCollisionEnter2D(Collision2D collision)  {
        if (collision.gameObject.tag == "Player") {
            //playerObject.GetComponent<PlayerController>().AddHeart();
            Destroy(gameObject);
        }
    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().SoundCoin();
            playerObject.GetComponent<PlayerController>().addCoin();
            Destroy(gameObject);
        }
    }
}
