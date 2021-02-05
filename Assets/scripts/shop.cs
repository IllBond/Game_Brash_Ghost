using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{

    public GameObject ShopHeart;
    public GameObject ShopSphere;
    public GameObject ShopCoin;
    public GameObject ShopGodSphere;

    public Button ShopHeartBTN;
    public Button ShopSphereBTN;
    public Button ShopCoinBTN;
    public Button ShopGodSphereBTN;

    public int coins;
    public Text coinsText;



    void Start()
    {
        coins = PlayerPrefs.GetInt("score");
        coinsText.text = "" + coins;

        if (PlayerPrefs.GetInt("Hearts_Presf") == 1)
        {
            ShopHeart.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Blood_Presf") == 1)
        {
            ShopSphere.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Coin_Presf") == 1)
        {
            ShopCoin.SetActive(false);
        }

        if (PlayerPrefs.GetInt("GodTime_Presf") == 1)
        {
            ShopGodSphere.SetActive(false);
        }

        if (PlayerPrefs.GetInt("score") < 400) {
            ShopHeartBTN.interactable = false;
            ShopSphereBTN.interactable = false;
            ShopCoinBTN.interactable = false;
            ShopGodSphereBTN.interactable = false;
        }
    }    
    
    public void Updater_my()
    {
        coins = PlayerPrefs.GetInt("score");
        coinsText.text = "" + coins;

        if (PlayerPrefs.GetInt("Hearts_Presf") == 1)
        {
            ShopHeart.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Blood_Presf") == 1)
        {
            ShopSphere.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Coin_Presf") == 1)
        {
            ShopCoin.SetActive(false);
        }

        if (PlayerPrefs.GetInt("GodTime_Presf") == 1)
        {
            ShopGodSphere.SetActive(false);
        }

        if (PlayerPrefs.GetInt("score") < 400) {

            ShopHeartBTN.interactable = false;
            ShopSphereBTN.interactable = false;
            ShopCoinBTN.interactable = false;
            ShopGodSphereBTN.interactable = false;

        }
    }

    public void BTN_ShopHeart()
    {
        if (PlayerPrefs.GetInt("score") >= 400)
        {
            PlayerPrefs.SetInt("Hearts_Presf", 1);
            ShopHeart.SetActive(false);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 400);
            Updater_my();
        }
    }


    public void BTN_ShopSphere()
    {
        if (PlayerPrefs.GetInt("score") >= 400)
        {
            PlayerPrefs.SetInt("Blood_Presf", 1);
            ShopSphere.SetActive(false);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 400);
            Updater_my();
        }
    }


    public void BTN_ShopCoin()
    {
        if (PlayerPrefs.GetInt("score") >= 400)
        {
            PlayerPrefs.SetInt("Coin_Presf", 1);
            ShopCoin.SetActive(false);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 400);
            Updater_my();
        }
    }


    public void BTN_ShopGodSphere()
    {
        if (PlayerPrefs.GetInt("score") >= 400)
        {
            PlayerPrefs.SetInt("GodTime_Presf", 1);
            ShopGodSphere.SetActive(false);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 400);
            Updater_my();
        }
    }



}
