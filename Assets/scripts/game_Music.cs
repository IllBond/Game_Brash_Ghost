using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class game_Music : MonoBehaviour {

    private AudioSource m_MyAudioSource;
 
    public GameObject music;
    public GameObject MusicOn;
    public GameObject MusicOff;
    public AudioSource Audio_A;
    public AudioClip ClickButton_A;



    void Start () {
        m_MyAudioSource = music.GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("music") == 0)
        {
            BTN_MusicOff();
        }
        else if (PlayerPrefs.GetInt("music") == 1)
        {
            BTN_MusicOn();
        }
    }   
    
    
    public void BTN_MusicOn() {

          PlayMusic(ClickButton_A);
          m_MyAudioSource.Play();
          MusicOn.SetActive(false);
          MusicOff.SetActive(true);
          PlayerPrefs.SetInt("music", 1);
    }

    public void BTN_MusicOff() {
           PlayMusic(ClickButton_A);
           m_MyAudioSource.Stop();
           MusicOn.SetActive(true);
           MusicOff.SetActive(false);
           PlayerPrefs.SetInt("music", 0);
    }


    public void PlayMusic(AudioClip music) {
        Audio_A.PlayOneShot(music);
    }

}
