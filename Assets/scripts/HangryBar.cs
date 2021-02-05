using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HangryBar : MonoBehaviour
{

    public Image bar;
    public float fill;

    void Start() {
        fill = 0.0f;
    }

    void DownFill() {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isState == "isWolf" || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isState == "isFly") {
            fill -= Time.deltaTime * 0.05f;
        } else {
            fill = fill*1;
        }

        bar.fillAmount = fill;
    }

    void Update() {
        DownFill();
    }
}
