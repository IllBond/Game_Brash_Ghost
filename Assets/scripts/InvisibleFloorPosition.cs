using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleFloorPosition : MonoBehaviour
{
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
