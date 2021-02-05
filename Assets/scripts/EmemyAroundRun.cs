using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyAroundRun : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(45, 90)) * Time.deltaTime);
    }
}
