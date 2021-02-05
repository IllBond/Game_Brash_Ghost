using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus_Blood : MonoBehaviour
{
    private GameObject playerObject;

    private void Start() {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().SoundBonus();
            if (playerObject.GetComponent<HangryBar>().fill < 1.0f)
            {
                playerObject.GetComponent<HangryBar>().fill += 0.1f;
            }
            Destroy(gameObject);
        }
    }
}
