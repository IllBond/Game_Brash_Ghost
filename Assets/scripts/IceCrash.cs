using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCrash : MonoBehaviour
{

    private GameObject playerObject;
    public int test;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void tap () {
        test++;
        playerObject.GetComponent<PlayerController>().tapToIce();
    }
}
