using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickUI : MonoBehaviour
{
    public AudioSource Audio_A;
    public AudioClip ClickButton_A;

    public void PlayClick () {
        Audio_A.PlayOneShot(ClickButton_A);
    }
}
