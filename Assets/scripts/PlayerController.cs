using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //test
    public float test;
    public bool isCloud = false;

    //
    public AudioSource soundTheme;
    // Контролируемые данные
    public float speed; // Скорость перемешения
    public float jumpForce; // Сила прыжка
    public GameObject vfx_steam;
    public GameObject vfx_smoke;
    public GameObject vfx_any;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Sprite[] iceSkins;
    public int whatIsTap = 0;
    private bool isIce = false;
    public float checkRadius;
    public CameraController cam;
    public int heartsCount;
    private float novPostiionPlayer = 0f;

    // Жизни
    public GameObject heart;
    public GameObject hearts;
    public int startHeartsValue;
    public int coorXPositionHeart = 0;
    private int rangeHeart = 2;


    // Кнопка возрадиться
    public GameObject RestartButtonRebith_text;
    public Button RestartButtonRebith_btn;
    public float timeToRestartButtonRebith;
    public float timeToRestartButtonRebith_prev;
    public float timeToRestartButtonRebith_NOW;
   
    
    // Кнопка возрадиться
    public GameObject RestartButtonRebith_ADS;
    //public Button RestartButtonRebith_btn;



    // Монеты
    public int coins;
    public Text coinsText;

    // Расстояние
    public int dist;
    public Text distText;
    public GameObject best;
    public float bestDistance;

    //Голод
    public GameObject bottleFill;
    public GameObject BloodStart;
    public GameObject CoinStart;

    //Неуязвимость
    public bool isGodMode = false;
    public int godTime;
    public float startGodTime;
    public GameObject godSphere;
    //Кнопки

    //Замедление времени
    public bool isSpeedTime = false;
    public int speedTime = 7;
    public float startSpeedTime;

    //Когда конец игры

    public float needToWin = 100000000000000;
    public int nowLVL = 0;
    public string nextLevel = "menu";
    public bool isWin = false;
    

    public AudioSource Audio_A;
    public AudioClip dmg_A;
    public AudioClip bonus_A;
    public AudioClip coin_A;
    public AudioClip gameOver_A;
    public AudioClip fly_jump_A;
    public AudioClip fallen_A;
    public AudioClip ClickButton_A;
    public AudioClip IceButton_A;
    public AudioClip error_A;
    public AudioClip win_A;

    public GameObject jumpBTN;
    public GameObject fallenBTN;
    public GameObject cloudfallenBTN;
    public GameObject wolfBTN;
    public GameObject pause;
    public GameObject Win;
    public GameObject ice;
    public GameObject buttons;
    public GameObject gameOverBlock;
    public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject Get_Damage;
    public GameObject Get_Bonuses;
    public GameObject pauseBTN;

    //Классы текущего обьекта
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D cl;
    private Animator anim;
    //Состояние
    public string isState;
    private string isRun = "isRun";
    private string isFly = "isFly";
    private string isJump = "isJump";
    private string isWolf = "isWolf";
    private string isFallen = "isFallen";
    //public bool isSpeed = false;
    //Для анимации
    private bool isBirdSmoke = false;

    public int JumpCount = 2;
    private int Jumper;

    void Start() {

        Time.timeScale = 1f;
        Jumper = JumpCount;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cl = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        isState = isRun;
        hearts = GameObject.FindGameObjectWithTag("hearts");
        coins = PlayerPrefs.GetInt("score");

        bestDistance = PlayerPrefs.GetInt("bestDistance");

        Instantiate(
            best,
            new Vector3(bestDistance, 0.9f, transform.position.z + 1),
            Quaternion.identity
        );

        coinsText.text = "" + coins;
        distText.text = "" + 0;

        timeToRestartButtonRebith_NOW = Time.time;
        timeToRestartButtonRebith_prev = Time.time;


        if (PlayerPrefs.GetInt("GodTime_Presf") == 1)
        {
            godTime = 7;
        }

        if (PlayerPrefs.GetInt("Hearts_Presf") == 1)
        {
            startHeartsValue = 3;
        }



        if (PlayerPrefs.GetInt("Blood_Presf") == 1)
        {
            GameObject GameItem = Instantiate(
                       BloodStart,
                       new Vector3(68, 1, 0),
                       Quaternion.identity);
            Destroy(GameItem, 15f);
        }

        if (PlayerPrefs.GetInt("Coin_Presf") == 1)
        {
            GameObject GameItem = Instantiate(
                       CoinStart,
                       new Vector3(45, 1, 0),
                       Quaternion.identity);
            Destroy(GameItem, 15f);
        }

        for (int i = 0; i < startHeartsValue; i++) {
            Instantiate(
                heart,
                new Vector3(hearts.transform.position.x + coorXPositionHeart, hearts.transform.position.y, hearts.transform.position.z),
                Quaternion.identity,
                hearts.transform
            );
            coorXPositionHeart = coorXPositionHeart + rangeHeart;
        }

    }


    void Update() {

        timeToRestartButtonRebith_NOW = Time.time;
        //cloudfallenBTN.SetActive(false);
        run();

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            jump();
        }


     
        if (transform.position.x+10 >= needToWin*10 && isWin == false) {
            winF();
        }
        
        novPostiionPlayer = transform.position.x + 10;
        distText.text = "" + Mathf.Round(novPostiionPlayer / 10);

        if (isGodMode == true) {
            if (Time.time > startGodTime + godTime) {
                isGodMode = false;
            }
        }

        if (isSpeedTime == true) {
            if (Time.time > startSpeedTime + speedTime) {
                isSpeedTime = false;
                Time.timeScale = 1f;
                pauseBTN.SetActive(true);
                soundTheme.pitch = 1f;
            }
        }


        if (isState == isRun) {
            cl.size = new Vector2(0.9f, 0.9f);
            cl.offset = new Vector2(-0.2f, 0.2f);
            wolfBTN.SetActive(true);
            // fallenBTN.SetActive(false); 
        }

        if (isState == isFly) {
            cl.size = new Vector2(1f, 1.5f / 2);
            cl.offset = new Vector2(-0f, -0.3f);
            wolfBTN.SetActive(false);
            fallenBTN.SetActive(true);
            anim.SetBool("isBird", true);
        }

        if (isState == isJump) {

            cl.size = new Vector2(0.9f, 0.9f);
            // cl.offset = new Vector2(-0.2f, -0.05f);
            wolfBTN.SetActive(false);
            fallenBTN.SetActive(true);
            anim.SetBool("isWolf", false);
            anim.SetBool("isJump", true);
        }

        if (isState == isWolf) {


            //wolfBTN.SetActive(false);
            //cl.size = new Vector2(1f, 0.25f);
            //cl.offset = new Vector2(0.05f, -0.1f);
            fallenBTN.SetActive(false);

        }

        if (isState == isFallen) {
            cl.size = new Vector2(0.9f, 0.9f);
            cl.offset = new Vector2(-0.2f, 0.2f);
            wolfBTN.SetActive(false);
            fallenBTN.SetActive(false);
            anim.SetBool("isFallen", true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {


        if (collision.gameObject.tag == "Ground") {
            Jumper = JumpCount;
            // isSpeed = false;
            if (isState == isFallen) {
                vfxEffect(vfx_any);
            }

            if (isState == isFly) {
                vfxEffect(vfx_smoke);
            }

            if (isState != isWolf) {
                isState = isRun;
                wolfBTN.SetActive(true);
                fallenBTN.SetActive(false);
                cl.size = new Vector2(1f, 1.5f);
                anim.SetBool("isFallen", false);
                anim.SetBool("isBird", false);
                anim.SetBool("isJump", false);
                isBirdSmoke = false;
            }
        }

        if (collision.gameObject.tag == "Cloud")
        {
            Jumper = JumpCount;
            // isSpeed = false;
            if (isState == isFallen)
            {
                vfxEffect(vfx_any);
            }

            if (isState == isFly)
            {
                vfxEffect(vfx_smoke);
            }

            if (isState != isWolf)
            {
                cloudfallenBTN.SetActive(true);
                isState = isRun;
                wolfBTN.SetActive(true);
                fallenBTN.SetActive(false);
                cl.size = new Vector2(1f, 1.5f);
                /// // / //
                anim.SetBool("isFallen", false);
                anim.SetBool("isBird", false);
                anim.SetBool("isJump", false);
                isBirdSmoke = false;
            }
        }


    }

    public void vfxEffect(GameObject value) {
        GameObject effect = Instantiate(
            value,
            new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 0.5f, GetComponent<Transform>().position.z),
            Quaternion.identity);
        Destroy(effect, 5f);
    }


    public void run() {


        rb.velocity = new Vector2(speed, rb.velocity.y);
        //Что бы не проавливались под пол
        if (GetComponent<Transform>().position.y < 0.6649999f) {
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0.6649999f);
        }

        //Что бы не проавливались под пол 
        if (GetComponent<Transform>().position.y > 16f) {
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 16f);
        }

        if (GetComponent<HangryBar>().fill <= 0)
        {

            speed = 20;
            //isSpeed = true;
            anim.SetBool("isWolf", false);
        }
    }

    public void addCoin() {
        coins = coins + 1;
        PlayerPrefs.SetInt("score", coins);
        coinsText.text = "" + coins;
    }   
        
    
    public void add200Coin() {
        coins = coins + 100;
        PlayerPrefs.SetInt("score", coins);
        coinsText.text = "" + coins;
    }   
    


        
    
    public void GiveCoin(int coinPiece) {
        coins = coins - coinPiece;
        PlayerPrefs.SetInt("score", coins);
        coinsText.text = "" + coins;
    }     
    
    
   
    
  

    public void godMode() {
        startGodTime = Time.time;
        isGodMode = true;
        GameObject sphereGod = Instantiate(
             godSphere,
             new Vector3(transform.position.x, transform.position.y, transform.position.z),
             Quaternion.identity,
             this.transform
         );

        Destroy(sphereGod, godTime);
    }

    public void quickTime() {
        startSpeedTime = Time.time;
        isSpeedTime = true;
        Time.timeScale = 2.0f;
        pauseBTN.SetActive(false);
        soundTheme.pitch = 1.1f;
    }

    public void SwitchCloudBTN() {
        cloudfallenBTN.SetActive(false);
        fallenBTN.SetActive(true);
        isState = isJump;
    }

    public void slowTime() {
        startSpeedTime = Time.time;
        isSpeedTime = true;
        Time.timeScale = 0.5f;
        pauseBTN.SetActive(false);
        soundTheme.pitch = 0.8f;
    }

    public void superJump() {
        rb.velocity = Vector2.up * jumpForce*1.5f;
    }

    public void jump() {
        cloudfallenBTN.SetActive(false);
        
        speed = 20;
        //isSpeed = true;
        isState = isJump;

        if (isState == isRun || isState == isWolf || Jumper > 0) {
            PlayMusic(fly_jump_A);
            isState = isJump;
            rb.velocity = Vector2.up * jumpForce;
            rb.gravityScale = 8;
            Jumper--;
        } else if (isState == isJump || isState == isFly) {

            if (GetComponent<HangryBar>().fill > 0) {
                PlayMusic(fly_jump_A);
                isState = isFly;
                if (!isBirdSmoke)
                {
                    vfxEffect(vfx_smoke);
                }
                isBirdSmoke = true;
                rb.velocity = Vector2.up * jumpForce / 2;
                rb.gravityScale = 4;
            }
            else {
                PlayMusic(IceButton_A);
            }
        }
    }

    public void trampoline() {
        cloudfallenBTN.SetActive(false);
        PlayMusic(fly_jump_A);
        speed = 20;
        isState = isJump;
        if (isState == isRun || isState == isWolf || isState == isFallen || isState == isFly || isState == isJump) {
            isState = isJump;
            rb.velocity = Vector2.up * jumpForce * 1.5f;
            rb.gravityScale = 8;
        }
    }
        
    



    public void flyTransform()  {
        isState = isFly;
        vfxEffect(vfx_steam);
        cl.size = new Vector2(1f, 1.5f / 2);
    }

    public void fallen() {
        PlayMusic(fallen_A);
        isState = isFallen;
        rb.gravityScale = 8;
        rb.velocity = Vector2.up * -jumpForce * 3;
    }

    public void cloudFallen() {
        isState = isJump;
        cloudfallenBTN.SetActive(false);
        fallenBTN.SetActive(true);
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.20f);

    }


    public void wolfTransform() {
        if (GetComponent<HangryBar>().fill > 0)
        {

            //cl.size = new Vector2(1f*2, 1.5f);
            if (isState == isRun)
            {
                isState = isWolf;
                speed = 40;
                anim.SetBool("isWolf", true);
            }
            else
            {
                isState = isRun;
                speed = 20;
                anim.SetBool("isWolf", false);
            }
        } else {
            PlayMusic(IceButton_A);
        }
    }    
    

    
    public void Damage() {
        heartsCount = hearts.transform.childCount;
        PlayMusic(dmg_A);
        if (isGodMode == false) {
            DamageBorder();
            if (heartsCount > 1) {
                    Destroy(hearts.transform.GetChild(heartsCount - 1).gameObject);
                    godMode();
                    coorXPositionHeart = coorXPositionHeart - rangeHeart;
            }  else {
                    Destroy(hearts.transform.GetChild(heartsCount - 1).gameObject);
                    godMode();
                    coorXPositionHeart = coorXPositionHeart - rangeHeart;
                    GameOver();
             }
        }
    }

    public void BonusgodMode() {
        godMode();
    }

    public void DamageBorder() {
        Get_Damage.SetActive(true);
        if (!isGodMode) {
            Get_Bonuses.GetComponent<Image>().CrossFadeAlpha(0, 0.0f, false);
        }
        Get_Damage.GetComponent<Image>().CrossFadeAlpha(255, 0.0f, false);
        Get_Damage.GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
    }    
    
    public void BonusBorder() {
        Get_Bonuses.SetActive(true);
        Get_Damage.GetComponent<Image>().CrossFadeAlpha(0, 0.0f, false);
        Get_Bonuses.GetComponent<Image>().CrossFadeAlpha(255, 0.0f, false);
        Get_Bonuses.GetComponent<Image>().CrossFadeAlpha(0, 0.5f, false);
    }
    

    public void AddHeart() {
        heartsCount = hearts.transform.childCount;
        if (heartsCount < startHeartsValue) {
            Instantiate(
                heart,
                new Vector3(hearts.transform.position.x + coorXPositionHeart, hearts.transform.position.y, hearts.transform.position.z),
                Quaternion.identity,
                hearts.transform
            );
            coorXPositionHeart = coorXPositionHeart + rangeHeart;
        } 
    }


    public void gamePause() {
        pause.SetActive(true);
        Time.timeScale = 0f;
        buttons.SetActive(false);
        soundTheme.volume = 0.3f;
    }

    public void winF() {
        Win.SetActive(true);
        Time.timeScale = 0f;
        buttons.SetActive(false);
        PlayMusic(win_A);
        isWin = true;
        if (nowLVL >= PlayerPrefs.GetInt("lvl") ) {
            PlayerPrefs.SetInt("lvl", nowLVL + 1);
        }
        
    }   
    
    
    public void nextLevelF() {
        SceneManager.LoadScene(nextLevel);
    }




    public void offButtonsAndPause() {
        pauseBTN.SetActive(false);
        buttons.SetActive(false);

    }    
    
    public void onButtonsAndPause() {
        pauseBTN.SetActive(true);
        buttons.SetActive(true);
    }
    


    public void OnIce() {
        ice.GetComponent<Image>().sprite = iceSkins[whatIsTap];
        ice.SetActive(true);
        offButtonsAndPause();
    }   
    
    public void OffIce() {
        ice.GetComponent<Image>().sprite = iceSkins[whatIsTap];
        ice.SetActive(false);
        whatIsTap = 0;
        onButtonsAndPause();
    }    
    
    public void tapToIce() {
        PlayMusic(IceButton_A);
        whatIsTap++;
        if (whatIsTap < 5) {
            ice.GetComponent<Image>().sprite = iceSkins[whatIsTap];
        } else {
            whatIsTap = 0;
            OffIce();
        }
    }


    public void gameResume() {
        pause.SetActive(false);
        Time.timeScale = 1f;
        buttons.SetActive(true);
        soundTheme.volume = 1f;
    }

    public void GameOver() {


        pauseBTN.SetActive(false);

        PlayMusic(gameOver_A);
        if (transform.position.x > bestDistance) {
            PlayerPrefs.SetInt("bestDistance", Convert.ToInt32(transform.position.x));
        }


        if (PlayerPrefs.GetInt("score") >= 100) {
            RestartButtonRebith_btn.interactable = true;
            RestartButtonRebith_ADS.SetActive(false);
        } else  {
            RestartButtonRebith_btn.interactable = false;
            RestartButtonRebith_ADS.SetActive(true);
        }

        Time.timeScale = 0f;
        gameOverBlock.SetActive(true);
        buttons.SetActive(false);

    }   
    
    public void HidengameOverBlock() {
        Time.timeScale = 1f;
        gameOverBlock.SetActive(false);
        buttons.SetActive(true);
    }      
    
    
    public void resest_timeToRestartButtonRebith_prev() {
        timeToRestartButtonRebith_prev = Time.time;
    }
    
    public void RestartGame() {
        SoundClick();
        Time.timeScale = 1f;
        // SceneManager.LoadScene("Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  
    
    public string GetIsState() {
        return isState;
    }   
    
    public void SoundCoin() {
        PlayMusic(coin_A);
    }     
    
    public void SoundClick() {
        PlayMusic(ClickButton_A);
    }    
    
    public void SoundBonus() {
        PlayMusic(bonus_A);
    }    
    
    public void PlayMusic(AudioClip music) {
        Audio_A.PlayOneShot(music);
    }

}
