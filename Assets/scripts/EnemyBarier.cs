using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarier : MonoBehaviour
{

    public GameObject barier;
    private GameObject player;
    private int distanceTiSpawn;
    private bool isSpawn = true;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Spawn() {
        GameObject barierObj = Instantiate(
            barier,
            new Vector3(GetComponent<Transform>().position.x - 2, barier.GetComponent<Transform>().position.y, barier.GetComponent<Transform>().position.z),
            Quaternion.identity);
        Destroy(barierObj, 15f);


    }

    void Update() {
        if (isSpawn && GetComponent<Transform>().position.x - player.GetComponent<Transform>().position.x < 25) {
            Invoke("Spawn", 1f);
            isSpawn = false;
        }
    }
}
