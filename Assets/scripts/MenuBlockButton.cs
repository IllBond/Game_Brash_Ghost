using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBlockButton : MonoBehaviour
{

    public Button btn_Shop;
    public Button btn_Game2;
    public GameObject txt_Shop;
    public GameObject txt_Game2;

    void Start() {
        if (PlayerPrefs.GetInt("bestDistance") > 50) {
            txt_Shop.SetActive(false);
            btn_Shop.interactable = true;
        } 
        
        if (PlayerPrefs.GetInt("bestDistance") > 100) {
            txt_Game2.SetActive(false);
            btn_Game2.interactable = true;
        }




    }
}
