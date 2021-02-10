using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class game_Button : MonoBehaviour
{
    private Coroutine showAd;

    private string gameId = "4005073";
    private string type = "video";

    private bool testMode = false;



    public GameObject playerObject;
    private PlayerController PlayerController;
    public int test = 1;

    public AudioSource Audio_A;
    public AudioClip ClickButton_A;



    private void Start()
    {
        PlayerController = playerObject.GetComponent<PlayerController>();
        Advertisement.Initialize(gameId, testMode);
    }

    public void jump()
    {
        PlayerController.jump();
    }   

    public void fly()
    {
        PlayerController.flyTransform();
    }  
    
    public void fallen()
    {
        PlayerController.fallen();
    }
       
    public void cloudfallen() {
        PlayerController.cloudFallen();
    }
    
    public void wolf() { 
        PlayerController.wolfTransform();
    }     
    
    public void pause() {
        PlayerController.gamePause();
    }      
    
    public void resume() {
        PlayerController.gameResume();
    }    
    
    public void restart() {
        PlayerController.RestartGame();
    }  
    
   
    public void rebirth() {
        PlayerController.AddHeart();
        PlayerController.HidengameOverBlock();
        PlayerController.pauseBTN.SetActive(true);
        PlayerController.resest_timeToRestartButtonRebith_prev();
        PlayerController.GiveCoin(100);
    }

    public void rebirthAD() {
        showAd = StartCoroutine(ShowAd_f());
    }    
    
    

   
    IEnumerator ShowAd_f()
    {
        while (true)
        {
            Debug.Log("Ready");
            if (Advertisement.IsReady(type)) {
                Advertisement.Show(type);
               

                PlayerController.add200Coin();



                if (PlayerPrefs.GetInt("score") >= 100)
                {
                    PlayerController.RestartButtonRebith_btn.interactable = true;
                    PlayerController.RestartButtonRebith_ADS.SetActive(false);
                } else {
                    PlayerController.RestartButtonRebith_btn.interactable = false;
                    PlayerController.RestartButtonRebith_ADS.SetActive(true);
                }


               // StopCoroutine(showAd);
                /* PlayerController.AddHeart();
                 PlayerController.HidengameOverBlock();
                 PlayerController.pauseBTN.SetActive(true);
                 PlayerController.resest_timeToRestartButtonRebith_prev();*/
            }

            yield return new WaitForSeconds(1f);
        }
    }

}
