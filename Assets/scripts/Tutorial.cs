using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tutorial : MonoBehaviour
{
    public GameObject BTN_Jump;
    public GameObject BTN_Fast;
    public GameObject BTN_Fallen;
    public GameObject CLoudFalen;

    public GameObject tut1;
    public GameObject tut2;
    public GameObject tut3;
    public GameObject tut4;
    public GameObject tut5;
    public GameObject tut6;
    public GameObject tut7;    
    public GameObject tut8;
    public GameObject tut9;
    public GameObject tut10;
    public GameObject tut11;
    public GameObject tut12;


    public GameObject invBLOCK;



    public int whatIsTut = 1;
    public int dis;


    public GameObject playerObject;
    private PlayerController PlayerController;

    void Start() {
        PlayerController = playerObject.GetComponent<PlayerController>();
        BTN_Jump.SetActive(false);
        BTN_Fast.SetActive(false);
        BTN_Fallen.SetActive(false);
        CLoudFalen.SetActive(false);


    }


    void Update() {
        dis = Convert.ToInt32(PlayerController.transform.position.x);


     
            switch (dis)
            {
                case 50:
                    if (whatIsTut == 1) {
                        Tutorial_1_Spawn();
                    }
                    break;
                case 100:
                    if (whatIsTut == 2) {
                        Tutorial_2_Spawn();
                    }
                    break;
                case 150:
                    if (whatIsTut == 3) {
                        Tutorial_3_Spawn();
                    }
                    break;
                case 200:
                    if (whatIsTut == 4) {
                        Tutorial_4_Spawn();
                    }
                    break;
                case 220:
                    if (whatIsTut == 5){
                        Tutorial_5_Spawn();
                    }
                    break;
                case 270:
                    if (whatIsTut == 6){
                        Tutorial_6_Spawn();
                    }
                    break;
                case 320:
                    if (whatIsTut == 7){
                        Tutorial_7_Spawn();
                    }
                    break;
                case 370:
                    if (whatIsTut == 8){
                        Tutorial_8_Spawn();
                    }
                    break;
                case 470:
                    if (whatIsTut == 9){
                        Tutorial_9_Spawn();
                    }
                    break;
                case 520:
                    if (whatIsTut == 10){
                        Tutorial_10_Spawn();
                    }
                    break;
                case 560:
                    if (whatIsTut == 11){
                        Tutorial_11_Spawn();
                    }
                    break;
                case 570:
                    if (whatIsTut == 12){
                        over();
                    }
                    break;
                default:
                    break;
            }
        
    }

    void Tutorial_1_Spawn() {
        tut1.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }    
    
    void Tutorial_2_Spawn() {
        tut2.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }

    void Tutorial_3_Spawn() {
        tut3.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }    
    
    void Tutorial_4_Spawn() {
        tut4.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }   
    
    void Tutorial_5_Spawn() {
        tut5.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }     
    void Tutorial_6_Spawn() {
        BTN_Jump.SetActive(true);
        tut6.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }  
    
    void Tutorial_7_Spawn() {
        tut7.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }   
    void Tutorial_8_Spawn() {
       
        CLoudFalen.SetActive(true);
        tut8.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }   
    void Tutorial_9_Spawn() {
        PlayerController.jump();
        PlayerController.superJump();

        BTN_Fallen.SetActive(true);
        tut9.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }    
    
    void Tutorial_10_Spawn() {
        BTN_Fast.SetActive(true);
        tut10.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }   
        
    void Tutorial_11_Spawn() {
        BTN_Fast.SetActive(true);
        tut11.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }   
    
    void over() {
        tut12.SetActive(true);
        Time.timeScale = 0f;
        whatIsTut++;
    }

    
}
