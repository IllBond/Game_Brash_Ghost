using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_RNDCreateBack : MonoBehaviour
{
   public GameObject[] items; 
   public GameObject player; 


   public float distance = 0;
   public float LastSpawn = 0;
   public float distanceToSpawn;

   private Vector3 playerPosition;
   float coorMin;
   float coorMax;
   public bool testSpawn = false;
   public int WhatIsSpawn = 1;
   private int randomItem;
   private int stopDublicat;

    private int coorRND;


    void Update() {
        playerPosition = player.GetComponent<Transform>().position;
        distance = playerPosition.x;

        if (distance > 20 && distance - LastSpawn > distanceToSpawn) {
            GameObject spawnElement;
            if (testSpawn) {
               spawnElement = items[WhatIsSpawn];
            } else {
                randomItem = Random.Range(0, items.Length);
                while (randomItem == stopDublicat) {
                    randomItem = Random.Range(0, items.Length);
                }
                stopDublicat = randomItem;
                spawnElement = items[randomItem];
            }
            
            if (spawnElement.GetComponent<game_SpawnCoor>().isCoor) {
                 coorMin = spawnElement.GetComponent<game_SpawnCoor>().coorMin;
                 coorMax = spawnElement.GetComponent<game_SpawnCoor>().coorMax;
            }
            coorRND = Random.Range(30, 40);
                GameObject GameItem = Instantiate(
                   spawnElement,
                   new Vector3(playerPosition.x + coorRND, Random.Range(coorMin, coorMax), 5),
                   Quaternion.identity);
                LastSpawn = GameItem.transform.position.x - coorRND;
                Destroy(GameItem, 15f);
        }

    }
}
