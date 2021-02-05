using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class game_Button : MonoBehaviour
{

    public GameObject playerObject;
    private PlayerController PlayerController;
    public int test = 1;

    public AudioSource Audio_A;
    public AudioClip ClickButton_A;



    private void Start()
    {
        PlayerController = playerObject.GetComponent<PlayerController>();
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
        PlayerController.AddHeart();
        PlayerController.HidengameOverBlock();
        PlayerController.pauseBTN.SetActive(true);
        PlayerController.resest_timeToRestartButtonRebith_prev();
    }

}
