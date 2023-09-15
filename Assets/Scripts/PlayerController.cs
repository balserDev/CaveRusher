using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    bool myrevival;
    public GameObject RevivalPanel;
    public Text Revivaltext;
    [SerializeField]
    private float revivingtime = 3;
    [SerializeField]
    public bool OnbeingRevived;
    public bool ONMOVILE;
    public Staff stafador;
    public GameObject textbox;
    public Staff MyStaff;
    public bool Dead;
    public GameObject DeathPanel;
    public Text killedText;
    public Animator CameraAnimator;
    public GameObject Rocks;
    public int Bombs;
    public Text BombsText;
    public GameObject[] PowerUps;
    public GameObject TextEffect;
    public AudioClip[] ExtraSound;
    public GameObject Wings;
    public Sprite[] Wingsaskins;
    public GameObject Portal;
    public Text MiciferDialogText;
    public GameObject elevatorDarkenes;
    public GameObject[] EventRooms;
    public GameObject Elevator;
    public GameObject Chest;
    public GameObject ChestMines;
    public Sprite OpenChest;
    public Sprite ClosedChest;
    public GameObject ChestRoom;
    public SoundManager soundmanager;
    public AudioSource ClipAudiosource;
    public Store[] StoreBuyers;
    GameManager gamemanager;
    public GameObject Scene;
    public GameObject StoreScene;
    public float GlobalTimer;
    [SerializeField()]
    public float Score;
    public bool IsFalling = false;
    public Text ScoreText;
    [SerializeField()]
    float BestScore;
    public Text BestScoreText;
    Animator PlayerAnimator;
    [Header("Movement")]
    public float Speed;
    [SerializeField]
    float MovementInput;
    Rigidbody2D PlayerRigidbody;
    public GameObject[] sotoreui;
    public bool Resurreccion = false;
    public float dash;
    bool PlayerMove = false;
    float waiting;
    float MovementDireccion;
    int DirectionMove;
    public int MULTIPLAYER = 0;
    float trailefect;
    public bool Inmortality = false;
    public Text DashText;
    public Sprite[] ChestSprites;
    public bool OnRestart = true;
    float dirx;
    public float RestartTime;
    AdsManager ads;
    public bool ONadd;
    public Slider RotationSlider;
  
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerRigidbody.freezeRotation = true;
        
        BestScore = PlayerPrefs.GetFloat("Score");
        BestScoreText.text = PlayerPrefs.GetFloat("Score").ToString("F0");

        StartCoroutine(Inmortal());

    }
    private void FixedUpdate()
    {
        //Mobile Rotation Movement
        if(ONMOVILE == true)
        {
            PlayerRigidbody.velocity = new Vector2(MovementDireccion * 15, GetComponent<Rigidbody2D>().velocity.y);
            PlayerRigidbody.velocity = new Vector2(dirx, GetComponent<Rigidbody2D>().velocity.y);
        }
     
    }
    
    void Update()
    {
     if(ONMOVILE == true)
        {
            float MoveSpeed = RotationSlider.value;
            dirx = Input.acceleration.x * MoveSpeed;

            if (dirx > 1f)
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            if (dirx < -1f)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
        }    

      

        //MovileControllerEnd
        MouseInput();
        BombsText.text = Bombs.ToString();
        if(OnbeingRevived == true)
        {
            revivingtime -= Time.deltaTime;
            Revivaltext.text = revivingtime.ToString("F0");
        }
        // Changues the state of player on air
        if (IsFalling == true)
        {
            
            trailefect += Time.deltaTime;
            Wings.GetComponent<SpriteRenderer>().sprite = Wingsaskins[1];
            GlobalTimer += Time.deltaTime;
            Score = GlobalTimer;
            ScoreText.text = Score.ToString("F0");
            if(trailefect > 1.5)
            {
                GetComponent<TrailEfect>().enabled = true;
                trailefect = 0;
            }
            
        }
        else
        {
            Wings.GetComponent<SpriteRenderer>().sprite = Wingsaskins[0];
            GetComponent<TrailEfect>().enabled = false;
        }
        // KeybasedController
        MovementInput = Input.GetAxis("Horizontal");
        PlayerRigidbody.velocity = new Vector2(MovementInput * Speed, GetComponent<Rigidbody2D>().velocity.y);
        if (MovementInput > 0.1f)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        if (MovementInput < -0.1f)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }
      
        if (PlayerMove== true)
        {
            
            if (DirectionMove > 0)
            {
                MovementDireccion += Time.deltaTime;
            }
            else
            {
                if(DirectionMove < 0)
                {
                    MovementDireccion -= Time.deltaTime;
                }
            }
            MovementDireccion = Mathf.Clamp(MovementDireccion,-1, 1);
            PlayerRigidbody.velocity = new Vector2(MovementDireccion * 15, GetComponent<Rigidbody2D>().velocity.y);
            if (MovementDireccion> 0.1f)
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            if (MovementDireccion < -0.1f)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
        }
     
        if(Dead == false)
        {
            if(OnbeingRevived == false)
            {
                if (transform.position.y > 8f)
                {
                    YouLoose();
                    killedText.text = "Fear of heights";
                }
                if (transform.position.y < -8f)
                {
                    YouLoose();
                    Debug.Log("IsFalling");
                    killedText.text = "Gravity";
                }
            }
            
        }
       
    }
    //Resets the scene 
    public void AppRestart()
    {
        if (Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetFloat("Score", BestScore);
            PlayerPrefs.Save();
        }
        gamemanager.GetComponent<Monetaization>().OnDisable();
        Destroy(gamemanager.GetComponent<Monetaization>());
        SceneManager.LoadScene("Game");
    }
    // Gets call when using the Dash
    public void Dash()
    {
        if(dash>= 1)
        {
            dash--;     
            Text dasher = GameObject.Find("DashText").GetComponent<Text>();
            dasher.text = dash.ToString();
            ClipAudiosource.clip = ExtraSound[0];
            ClipAudiosource.Play();
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
            //GetComponent<Rigidbody2D>().drag = 0;
            transform.position += new Vector3(0, 4, 0) ;

            StartCoroutine(DasColor());
        }
   
    }
    //Dash adjustemnt Script
    IEnumerator DasColor()
    {
        
        ClipAudiosource.clip = ExtraSound[1];
        ClipAudiosource.Play();
        GetComponent<SpriteRenderer>().color = Color.cyan;
        yield return new WaitForSeconds(1f);
        if(Resurreccion == true)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            StartCoroutine(Inmortal());;
        }
       

    }

    //Demon Inmortality
    IEnumerator Inmortal()
    {
        Inmortality = true;
        if (Resurreccion == false)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
        }
      
        yield return new WaitForSeconds(3);
        if(Resurreccion == false)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1f);
        }
       
        Inmortality = false;

    }
    IEnumerator CameraShake()
    {
        CameraAnimator.SetBool("CameraShake", true);
        yield return new WaitForSeconds(1);
        CameraAnimator.SetBool("CameraShake", false);
    }

    IEnumerator DeathPanelF()
    {
        Debug.Log("Chesscake");
        OnRestart = true;
        DeathPanel.SetActive(true);
        if (Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetFloat("Score", BestScore);
            PlayerPrefs.Save();
        }
        yield return new WaitForSeconds(10);
        //if(OnRestart == true)
        //{
        //    SceneManager.LoadScene("Game");
        //}
       
    }
    //Gets call gen you Die
    void YouLoose()
    {
       
        if (Inmortality == false)
        {
            if (Resurreccion == false)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                IsFalling = false;           
                StartCoroutine(CameraShake());
                StartCoroutine(DeathPanelF());
                Dead = true;
                GetComponent<SpriteRenderer>().enabled = false;
               
            }
            else
            {
                TimeToRevive();

            }
        }
           
    }
   //  Player Revivival function
    public void Revival()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(CameraShake());
        StartCoroutine(Inmortal());
        PlayerRigidbody.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 1.5f, 0);
        IsFalling = true;
        Resurreccion = false;
        Color gate;
        Dead = false;
        gate = Portal.GetComponent<SpriteRenderer>().color;
        gate.a = 60f;
        Portal.GetComponent<BoxCollider2D>().enabled = false;
    }
    //Elebator Panel
    public void TimeToRevive()
    {
        StartCoroutine(RevivingTime());
    }
    public IEnumerator RevivingTime()
    {
        GetComponent<BoxCollider2D>().enabled = false;
       //GetComponent<PlayerController>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        revivingtime = 3;
        OnbeingRevived = true;
        Debug.Log("El puto es" + OnbeingRevived);
        RevivalPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        GetComponent<BoxCollider2D>().enabled = true;
       // GetComponent<PlayerController>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log(revivingtime + "TimerBaive");
        Revival();
        OnbeingRevived = false;
        RevivalPanel.SetActive(false);
    }
    IEnumerator ElevatorDown()
    {
        elevatorDarkenes.SetActive(true);
        yield return new WaitForSeconds(9);
        elevatorDarkenes.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            PlayerAnimator.SetBool("IsFalling",false);
            IsFalling = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            PlayerAnimator.SetBool("IsFalling", true);
            IsFalling = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "StoreEntry":
                stafador.enabled = false;
                stafador.RayDraw.enabled = false;
                int miciferestate = PlayerPrefs.GetInt("MiciferState");
                if (miciferestate == 0)
                {
                    MiciferDialogText.text = "Hello my name is micifer welcome to my store";
                    miciferestate++;
                    PlayerPrefs.SetInt("MiciferState", miciferestate);
                    PlayerPrefs.Save();
                }
                else
                {
                    MiciferDialogText.text = "Hello Again!!!";

                }
                soundmanager.PlaySong(2);
                Scene.SetActive(false);
                EventRooms[0].SetActive(true);
                sotoreui[0].SetActive(true);
                sotoreui[1].SetActive(true);
                sotoreui[2].SetActive(true);
                transform.position = new Vector3(0, -0.7f, 0);
                gamemanager.onStore = true;
                for (int i = 0; i < StoreBuyers.Length; i++)
                {

                    StoreBuyers[i].StoreRoll();
                }
                break;
            case "ChestRoom":
                stafador.RayDraw.enabled = false;
                stafador.enabled = false;
                soundmanager.PlaySong(2);
                Scene.SetActive(false);
                EventRooms[1].SetActive(true);
                transform.position = new Vector3(-1.5f, -0.7f, 0);
                Chest.SetActive(true);
                gamemanager.onStore = true;

                break;
            case "MineEntry":
                stafador.RayDraw.enabled = false;
                stafador.enabled = false;
                soundmanager.PlaySong(5);
                Scene.SetActive(false);
                EventRooms[5].SetActive(true);
                transform.position = new Vector3(-1.5f, -0.7f, 0);
                Chest.SetActive(true);
                gamemanager.onStore = true;

                break;
            case "ElevatorRoom":
                stafador.RayDraw.enabled = false;
                stafador.enabled = false;
                soundmanager.PlaySong(2);
                Scene.SetActive(false);
                EventRooms[2].SetActive(true);
                transform.position = new Vector3(1.5f, -0.7f, 0);
                gamemanager.onStore = true;
                break;
            case "Coin":
                gamemanager.coins = (gamemanager.coins + MULTIPLAYER) ;
                Destroy(collision.gameObject);
                ClipAudiosource.clip = ExtraSound[0];
                ClipAudiosource.Play();
                break;
            case "Exit":
                stafador.RayDraw.enabled = true;
                stafador.enabled = true;
                Elevator.GetComponent<BoxCollider2D>().enabled = true;
                soundmanager.PlaySong(1);
                Scene.SetActive(true);
                ChestMines.GetComponent<BoxCollider2D>().enabled = false;
                Rocks.SetActive(true);
                EventRooms[0].SetActive(false);
                EventRooms[1].SetActive(false);
                EventRooms[2].SetActive(false);
                EventRooms[3].SetActive(false);
                EventRooms[4].SetActive(false);
                EventRooms[5].SetActive(false);           
                elevatorDarkenes.SetActive(false);
                TextEffect.SetActive(false);
                textbox.SetActive(false);
                StartCoroutine(Inmortal());
                transform.position = new Vector3(0, 1.5f, 0);
                Chest.GetComponent<SpriteRenderer>().sprite = ClosedChest;
                Chest.GetComponent<BoxCollider2D>().enabled = true;
                ChestMines.GetComponent<SpriteRenderer>().sprite = ClosedChest;
                gamemanager.onStore = false;
                break;
            //case "Chest":
            //    gamemanager.coins += 10;
            //    collision.GetComponent<SpriteRenderer>().sprite = OpenChest;
            //    collision.GetComponent<BoxCollider2D>().enabled = false;
            //    ClipAudiosource.clip = Coin;
            //    ClipAudiosource.Play();
            //    TextEffect.SetActive(true);
              
            case "Elevator":
                stafador.RayDraw.enabled = false;
                stafador.enabled = false;
                PlayerRigidbody.mass = 50;
                StartCoroutine(ElevatorDown());
                soundmanager.PlaySong(3);
                GlobalTimer += 50;
                ScoreText.text = Score.ToString("F0");
                collision.GetComponent<BoxCollider2D>().enabled = false;
                break;
            
            case "PortalRoom":
                stafador.RayDraw.enabled = false;
                stafador.enabled = false;
                soundmanager.PlaySong(4);
                Scene.SetActive(false);
                EventRooms[3].SetActive(true);
                transform.position = new Vector3(1.5f, -0.7f, 0);
                if (Inmortality == false)
                {
                    Portal.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
                else
                {
                    Portal.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                }
                gamemanager.onStore = true;
                break;
            case "MagicRoom":
                stafador.RayDraw.enabled = false;
                stafador.enabled = false;
                soundmanager.PlaySong(4);
                Scene.SetActive(false);
                EventRooms[4].SetActive(true);
                transform.position = new Vector3(1.5f, -0.7f, 0);
                gamemanager.onStore = true;
                break;
            case "Bat":
                killedText.text = "Fear of bats";
                YouLoose();
                break;


        }

    }
    public void resureccion()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Color gate;
        gate = Portal.GetComponent<SpriteRenderer>().color;
        gate.a = 100f;
        Portal.GetComponent<BoxCollider2D>().enabled = true;
        Resurreccion= true;
    }

    public void hold(int Dir)
    {
        PlayerMove = true;
        DirectionMove = Dir;
    }
    public void Relese()
    {
        PlayerMove = false;
        DirectionMove = 0;
        MovementDireccion = 0;
    }
     public void ChestRool()
    {
      


    }

    void MouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 raycasPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycasPos, Vector2.zero);
            if (hit.transform != null)
            {
                switch (hit.transform.tag)
                {
                    case "Chest":
                    int Drop = Random.Range(1, 4);
                        if(Drop ==2)//Coins
                        {
                           int CoinDrop = Random.Range(5, 31);
                            gamemanager.coins += CoinDrop;
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = OpenChest;
                            hit.transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;                      
                            TextEffect.SetActive(true);
                            TextEffect.transform.GetChild(1).GetComponent<Image>().sprite = ChestSprites[0];
                            TextEffect.transform.GetChild(0).GetComponent<Text>().text = "+" + CoinDrop.ToString();
                            ClipAudiosource.clip = ExtraSound[0];
                            ClipAudiosource.Play();

                        }
                        if(Drop == 1)//Dash
                        {
                            int CoinDrop = Random.Range(1, 3);
                            hit.transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = OpenChest;
                            dash += CoinDrop;
                            DashText.text = dash.ToString();
                            TextEffect.SetActive(true);
                            TextEffect.transform.GetChild(1).GetComponent<Image>().sprite = ChestSprites[1];
                            TextEffect.transform.GetChild(0).GetComponent<Text>().text = "+" + CoinDrop.ToString();
                            ClipAudiosource.clip = ExtraSound[0];
                            ClipAudiosource.Play();
                        }
                        if (Drop == 3)//Bombs
                        {
                            int CoinDrop = Random.Range(1, 3);
                            hit.transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = OpenChest;
                            Bombs += CoinDrop;
                            BombsText.text = Bombs.ToString();
                            TextEffect.SetActive(true);
                            TextEffect.transform.GetChild(1).GetComponent<Image>().sprite = ChestSprites[2];
                            TextEffect.transform.GetChild(0).GetComponent<Text>().text = "+" + CoinDrop.ToString();
                            ClipAudiosource.clip = ExtraSound[0];
                            ClipAudiosource.Play();
                        }
                        break;
                    case "Mage":
                        PowerUps[0].SetActive(true);
                        MyStaff.StaffLoad = 100;
                        MyStaff.StafLoadtext.text = MyStaff.StaffLoad.ToString() + "%";
                        ClipAudiosource.clip = ExtraSound[4];
                        ClipAudiosource.Play();
                        break;
                    case "Bomb":
                       if (Bombs > 0)
                       {
                            ChestMines.GetComponent<BoxCollider2D>().enabled = true;
                            Bombs--;
                            Rocks.SetActive(false);
                            ClipAudiosource.clip = ExtraSound[2];
                            ClipAudiosource.Play();
                       }
                        break;
                    case "Portal":
                        Portal.GetComponent<BoxCollider2D>().enabled = false;
                        ClipAudiosource.clip = ExtraSound[3];
                        ClipAudiosource.Play();
                        Wings.SetActive(true);
                        break;


                }

            }
        }
    }

}
