using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg_Sphere_jump : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

}
