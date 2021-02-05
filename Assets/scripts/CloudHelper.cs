using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHelper : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            player.GetComponent<PlayerController>().SwitchCloudBTN();
           // player.GetComponent<PlayerController>().SoundCoin();
        }
    }

}
