using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class game_Button_menu : MonoBehaviour {

    public int isReset = 0;
    public int test = 0;






    public void BTN_PlayGamess() {
           Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("tutorial") != 1) {
            SceneManager.LoadScene("GameTutorial");
        } else {
            SceneManager.LoadScene("Game");
        }
    }    
    
    public void BTN_PlayGamess2() {
           Time.timeScale = 1f;
           SceneManager.LoadScene("Game2");
    }

    public void BTN_Menu() {
            SceneManager.LoadScene("Menu");
    }

    public void BTN_Shop() {
            SceneManager.LoadScene("Shop");
    }

    public void BTN_Tutorial() {
            SceneManager.LoadScene("Tutorial");
    }

    public void BTN_Setting() {
            SceneManager.LoadScene("Setting");
    }  
    
    public void BTN_About() {
           SceneManager.LoadScene("About");
    }    
    
    public void BTN_goToInst() {
        Application.OpenURL("https://www.instagram.com/ilya_bon/");
    }

    public void BTN_Reset() {

        isReset++;
        if (isReset >= 5) {
            PlayerPrefs.SetInt("bestDistance", -100);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("Blood_Presf", 0);
            PlayerPrefs.SetInt("Coin_Presf", 0);
            PlayerPrefs.SetInt("GodTime_Presf", 0);
            PlayerPrefs.SetInt("Hearts_Presf", 0);
            //PlayerPrefs.SetInt("tutorial", 0);
        }
        
    }    
    
    public void BTN_cheat() {

        isReset++;
        if (isReset >= 10) {
            PlayerPrefs.SetInt("bestDistance", 5000);
            PlayerPrefs.SetInt("score", 5000);

        }
        
    }


}
