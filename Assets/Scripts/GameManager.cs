using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool CallRotation = true;
    public GameObject MainCameraGO;
    public GameObject EnemyContainer;
    public GameObject[] EventInstances;
    Camera MainCamera;
    public Sprite[] Items;
    public int coins;
    public Text CoinsText;
    PlayerController playerController;
    public GameObject Chest;
    public GameObject Coin;
    public GameObject StartPanel;
    public GameObject PlataformType01;
    public GameObject BG;
    public GameObject Scene;
    GameObject Player;
    public float InstanceTime;
    public float CoinTimer;
    public float Depth;
    public float globaltimer;
    public int pricetag;
    public bool onStore;
 
    float EnemyTimer;
    bool Starter = false;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 30;


        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        int a = Items.Length;
        Debug.Log(a + "Test");
        Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //RyCastMouse
        SkinUnlocker();
        if(Depth > 399 && Depth < 500)
        {
            if (CallRotation == true)
            {
                StartCoroutine(CameraRotation());
            }
        }
        else
        {
            MainCameraGO.GetComponent<Animator>().SetBool("Rotator", false);
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Debug.DrawRay(MainCamera.transform.position, mousepos - MainCamera.transform.position, Color.red);
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hIT");
                if (hit.transform.CompareTag("Chest"))
                {
                    Debug.Log("Money");
                }
            }

        }


        CoinsText.text = coins.ToString();
        if(onStore == false)
        {
            EnemyTimer += Time.deltaTime;
            globaltimer += Time.deltaTime;
            CoinTimer += Time.deltaTime;
            Depth = playerController.Score;
            if(EnemyTimer >= 15)
            {
                int Bats = Random.Range(1,4);
                EnemyTimer = 0;
                if(Depth>10)
                {
                    switch(Bats)
                    {
                        case 1:
                            EnemySpawn(EventInstances[Bats], new Vector3(0, -1, 0));
                        break;
                        case 2:
                            EnemySpawn(EventInstances[Bats], new Vector3(-6, -8, 0));
                            break;
                        case 3:
                            EnemySpawn(EventInstances[Bats], new Vector3(6, -8, 0));
                            break;

                    }
                    
                }
                
               
            }

            if (Starter == true)
            {
                InstanceTime += Time.deltaTime;
              if(Depth < 50)
              {
                    if (InstanceTime >= 1.5f)
                    {
                        PlataformInstanceType01();
                        InstanceTime = 0;

                    }
              }
                if(Depth > 49 && Depth < 100)
                {
                    if (InstanceTime >= 1.2f)
                    {
                        PlataformInstanceType01();
                        InstanceTime = 0;

                    }
                }
                if(Depth > 99)
                {
                    if (InstanceTime >= 0.8f)
                    {
                        PlataformInstanceType01();
                        InstanceTime = 0;
                    }
                }
                if (globaltimer >= 10)
                {
                    int evento;
                    if (Depth > 200)
                    {
                        //DemonPortalApears
                        evento = Random.Range(0, 8);
                    }
                    else
                    {
                        if (Depth > 100)
                        {
                            //MagicianApears
                            evento = Random.Range(0, 5);
                        }
                        else
                        {
                            if(Depth>49)
                            {
                                evento = Random.Range(0, 4);
                            }
                            else
                            {
                                evento = Random.Range(1, 4);
                            }
                            //Basics Apear
                           
                        }

                    }

                    switch (evento)
                    {
                        case 0://Mines
                            StartCoroutine(EventSpawn(EventInstances[9], new Vector3(-1.2f, -9, 0)));
                            break;
                        case 1:
                            //Elevtor
                            StartCoroutine(EventSpawn(EventInstances[4], new Vector3(-1.2f, -9, 0)));
                            break;
                        case 2:
                            //Store
                            StartCoroutine(EventSpawn(EventInstances[5], new Vector3(-1.25f, -9, 0)));
                            break;
                        case 3:
                            //Chest
                            StartCoroutine(EventSpawn(EventInstances[6], new Vector3(1.3f, -9, 0)));
                            break;
                        case 4:
                            //Magician
                            StartCoroutine(EventSpawn(EventInstances[7], new Vector3(1.3f, -9, 0)));
                            break;
                        case 5:
                            //DemonPortal
                            StartCoroutine(EventSpawn(EventInstances[8], new Vector3(1.3f, -9, 0)));
                            break;
                    }

                    globaltimer = 0;
                }
                if (CoinTimer >= 3)
                {
                    CoinInstance();
                    CoinTimer = 0;
                }

            }
           
        }
     


    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateCoins ()
    {
        CoinsText.text = coins.ToString();
       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="toinstance">Cordenada de la posicion de spawn</param>
    /// <param name="spawn"></param>
    
    IEnumerator EventSpawn(GameObject toinstance, Vector3 spawn)
    {
        Starter = false;
        yield return new WaitForSeconds(0.5f);
        GameObject NewPlataform;
        NewPlataform = Instantiate(toinstance);
        NewPlataform.transform.parent = Scene.transform;
        NewPlataform.transform.position = spawn;
        yield return new WaitForSeconds(1f);
        Starter = true;
    }
    IEnumerator CameraRotation()
    {
        CallRotation = false;
        MainCameraGO.GetComponent<Animator>().SetBool("Rotator", true);
        yield return new WaitForSeconds(10);
        MainCameraGO.GetComponent<Animator>().SetBool("Rotator", false);
        CallRotation = true;
    }
    

      
     void SkinUnlocker()
    {
  
       if (Depth > 100)
        {
        
            int Unlock01 = PlayerPrefs.GetInt("SkinUnlock01");
            if(Unlock01 <= 0)
            {
                PlayerPrefs.SetInt("SkinUnlock01", 1);
                PlayerPrefs.Save();
            }
        }
        if (Depth > 200)
        {
         
            int Unlock01 = PlayerPrefs.GetInt("SkinUnlock02");
            if (Unlock01 <= 0)
            {
                PlayerPrefs.SetInt("SkinUnlock02", 1);
                PlayerPrefs.Save();
            }
        }
        if (Depth > 300)
        {
            int Unlock01 = PlayerPrefs.GetInt("SkinUnlock03");
            if (Unlock01 <= 0)
            {
                PlayerPrefs.SetInt("SkinUnlock03", 1);
                PlayerPrefs.Save();
            }
        }
        if (Depth > 400)
        {
            int Unlock01 = PlayerPrefs.GetInt("SkinUnlock04");
            if (Unlock01 <= 0)
            {
                PlayerPrefs.SetInt("SkinUnlock04", 1);
                PlayerPrefs.Save();
            }
        }
        if (Depth > 500)
        {
            int Unlock01 = PlayerPrefs.GetInt("SkinUnlock05");
            if (Unlock01 <= 0)
            {
                PlayerPrefs.SetInt("SkinUnlock05", 1);
                PlayerPrefs.Save();
            }
        }
    }
   
    //public void EventSpawn (GameObject toinstance, Vector3 spawn)
    //{

    //    GameObject NewPlataform;
    //    NewPlataform = Instantiate(toinstance);
    //    NewPlataform.transform.parent = Scene.transform;
    //    NewPlataform.transform.position = spawn;
 
       
    //}
    public void EnemySpawn(GameObject toinstance, Vector3 spawn)
    {

        GameObject NewPlataform;
        NewPlataform = Instantiate(toinstance);
        NewPlataform.transform.parent = EnemyContainer.transform;
        NewPlataform.transform.position = spawn;


    }
    public void PlataformInstanceType01()
    {
        GameObject NewPlataform;
        NewPlataform = Instantiate(PlataformType01);
        NewPlataform.transform.parent = Scene.transform;
        NewPlataform.transform.position = new Vector3(Random.Range(-1.8f, 1.8f), -9, 0);
 
    }
    public void CoinInstance()
    {
        GameObject CoinInstance;
        CoinInstance = Instantiate(Coin);
        CoinInstance.transform.parent = Scene.transform.GetChild(0).transform;
        CoinInstance.transform.position = new Vector3(Random.Range(-2, 2), -9, 0);
    }
   

    public void GameStart()
    {
        Debug.Log("Dearrea");
        playerController.IsFalling = true;
        StartPanel.SetActive(false);
        Player.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        Starter = true;
    }

    public void OpenChest()
    {
        coins += 10;
        UpdateCoins();
        Chest.SetActive(false);
    }
 
  
   
    

}
