using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    
    int CrownUnlock;
    int MagnetUnlock;
    int FireUnlock;
    public AudioClip[] clips;
    public AudioSource audiosource;
    public int[] ObjDorection;
    public GameObject Hat;
    public GameObject Magnet;
    public GameObject Fire;
    public Text DashText;
    public Dialogs dialogs;
    public Sprite spirtetest;
   public Sprite[] skins;
    GameManager Gamemanager;
    public GameObject[] StoreUi;
    PlayerController PLAYER;
    [SerializeField]
    int pricetag;
    int coins;
    int ItemSelection;
    // Start is called before the first frame update
    void Start()
    {
        CrownUnlock = PlayerPrefs.GetInt("Crown");
        MagnetUnlock = PlayerPrefs.GetInt("Magnet");
        Gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dialogs = GameObject.Find("GameManager").GetComponent<Dialogs>();
        PLAYER = GameObject.Find("Player").GetComponent<PlayerController>();
        StoreRoll();
    }

    // Update is called once per frame
    void Update()
    {
        coins = Gamemanager.coins;
    }

    public void PlaySound(int Audio)
    {
        audiosource.clip = clips[Audio];
        audiosource.Play();
    }
    public void BuyItem()
    {
        if (coins >= pricetag)
        {
            Gamemanager.coins -= pricetag;
            Gamemanager.UpdateCoins();
            switch (ItemSelection)
            {
                case 1: //GoldItem
                    Gamemanager.coins++;
                    Gamemanager.UpdateCoins();
                    dialogs.MiciferScene01();
                    PlaySound(0);
                    break;

                case 2: //ResurectionDemon
                    PLAYER.resureccion();
                    PlaySound(0);
                    break;

                case 3: //Dash
                    PLAYER.dash++;
                    DashText.text = PLAYER.dash.ToString();
                    PlaySound(0);
                    break;
                case 4:
                    Hat.SetActive(true);
                    PLAYER.MULTIPLAYER = 2;
                    PlaySound(0);
                    break;
                case 5:
                    Magnet.SetActive(true);
                    PlaySound(0);
                    break;
                case 6:
                    Fire.SetActive(true);
                    PlaySound(0);
                    break;
            }
            StoreUi[0].SetActive (false);
            StoreUi[1].SetActive(false);
            StoreUi[2].SetActive(false);

        }
        else
        {
            PlaySound(1);
        }
    }
    public void StoreRoll()
    {
        int miciferestate = PlayerPrefs.GetInt("MiciferState");
        CrownUnlock = PlayerPrefs.GetInt("Crown");
        MagnetUnlock = PlayerPrefs.GetInt("Magnet");
        FireUnlock = PlayerPrefs.GetInt("Fire");
        if (FireUnlock > 0)
        {
            ItemSelection = Random.Range(1, 7);             
        }
        else
        {
            if(MagnetUnlock > 0)
            {
                ItemSelection = Random.Range(1, 6);
            }
            else
            {
             
                if (CrownUnlock > 0)
                {
                    ItemSelection = Random.Range(1, 5);
                 
                }
                else
                {
                    ItemSelection = Random.Range(1, 4);
                }
                
            }
     

        }
       
       
       
        Debug.Log(ItemSelection);

        switch (ItemSelection)
        {
            
            case 1: //GoldItem
                Debug.Log("Test02");
                pricetag = 5;
                transform.GetChild(0).GetComponent<Text>().text = pricetag.ToString("F0");
                GetComponent<Image>().sprite = skins[0];
                break;
            case 2: //ResurectionDemon
                pricetag = 15;
                transform.GetChild(0).GetComponent<Text>().text = pricetag.ToString("F0");
                GetComponent<Image>().sprite = skins[1];
                break;
            case 3: //Dash 
                pricetag = 5;
                transform.GetChild(0).GetComponent<Text>().text = pricetag.ToString("F0"); ;
                GetComponent<Image>().sprite = skins[2];
                break;
            case 4: //Crown
                pricetag = 20;
                transform.GetChild(0).GetComponent<Text>().text = pricetag.ToString("F0");
                GetComponent<Image>().sprite = skins[3];
                break;
            case 5: //Magnet
                pricetag = 30;
                transform.GetChild(0).GetComponent<Text>().text = pricetag.ToString("F0");
                GetComponent<Image>().sprite = skins[4];
                break;
            case 6: //Fire
                pricetag = 45;
                transform.GetChild(0).GetComponent<Text>().text = pricetag.ToString("F0");
                GetComponent<Image>().sprite = skins[5];
                break;

        }

        
    }
}
