using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class game_Button_menu_check_level : MonoBehaviour {

    public int isReset = 0;
    public int test;

    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button lvl4;
    public Button lvl5;
    public Button lvl6;
    public Button lvl7;
    public Button lvl8;
    public Button lvl9;
    public Button lvl10;

    private int lvl;

    void Start() {
        lvl = PlayerPrefs.GetInt("lvl");

        if (lvl == 0) {
            lvl = 1;
        }


            if (lvl >= 1) {
                lvl1.interactable = true;
            }
            if (lvl >= 2) {
                lvl2.interactable = true;
            }
            if (lvl >= 3) {
                lvl3.interactable = true;
            }
            if (lvl >= 4) {
                lvl4.interactable = true;
            }
            if (lvl >= 5) {
                lvl5.interactable = true;
            }
            if (lvl >= 6) {
                lvl6.interactable = true;
            }
            if (lvl >= 7) {
                lvl7.interactable = true;
            }
            if (lvl >= 8) {
                lvl8.interactable = true;
            }
            if (lvl >= 9) {
                lvl9.interactable = true;
            }
            if (lvl >= 10) {
                lvl10.interactable = true;
            }



    }



    public void level1() {
           Time.timeScale = 1f;
           SceneManager.LoadScene("Game1");
    }

    public void level2() {
            SceneManager.LoadScene("Game2");
    }

    public void level3() {
            SceneManager.LoadScene("Game3");
    }  
    
    public void level4() {
           Time.timeScale = 1f;
           SceneManager.LoadScene("Game4");
    }

    public void level5() {
            SceneManager.LoadScene("Game5");
    }

    public void level6() {
            SceneManager.LoadScene("Game6");
    }    

    public void level7() {
           Time.timeScale = 1f;
           SceneManager.LoadScene("Game7");
    }

    public void level8() {
            SceneManager.LoadScene("Game8");
    }

    public void level9() {
            SceneManager.LoadScene("Game9");
    }
    
    public void level10() {
            SceneManager.LoadScene("Game10");
    }

}
