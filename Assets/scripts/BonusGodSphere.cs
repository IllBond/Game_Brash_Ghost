using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusGodSphere : MonoBehaviour
{
    private GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))  {
            playerObject.GetComponent<PlayerController>().SoundBonus();
            playerObject.GetComponent<PlayerController>().godMode();
            Destroy(gameObject);
        }
    }
}
