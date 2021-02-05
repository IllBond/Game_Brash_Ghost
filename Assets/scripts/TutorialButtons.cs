using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtons : MonoBehaviour
{
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


    public AudioSource Audio_A;
    public AudioClip ClickButton_A;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void nextStep() {
        Audio_A.PlayOneShot(ClickButton_A);
        tut1.SetActive(false);
        tut2.SetActive(false);
        tut3.SetActive(false);
        tut4.SetActive(false);
        tut5.SetActive(false);
        tut6.SetActive(false);
        tut7.SetActive(false);
        tut8.SetActive(false);
        tut9.SetActive(false);
        tut10.SetActive(false);
        tut11.SetActive(false);

     

        Time.timeScale = 1f;
    }   
    
    public void startGame() {
        Audio_A.PlayOneShot(ClickButton_A);
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("tutorial", 1);
        SceneManager.LoadScene("Game");
    }
}
