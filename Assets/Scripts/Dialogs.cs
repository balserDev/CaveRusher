using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
    public PlayerController player;
    public AudioClip NewItemAudio;
    public AudioSource AudioSourceefect;
    public Sprite[] ItemSprites;
    public GameObject PanelNewItemPanel;
    public GameObject Crown;
    public GameObject Magnet;
    public GameObject Fire;
    int MiciferState = 1;
    public Text DialogTextBox;
    public GameObject CoinsToItem;
    string DialogText;
    
  
    void Start()
    {
        MiciferState = PlayerPrefs.GetInt("MiciferState");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        Debug.Log("MiciferState:" + MiciferState);
        CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
    }
    IEnumerator PanelNewItem(int Unlock)
    {
        PanelNewItemPanel.SetActive(true);
        switch(Unlock)
        {
            case 0:
                PanelNewItemPanel.transform.GetChild(0).GetComponent<Image>().sprite = ItemSprites[0];
                PanelNewItemPanel.transform.GetChild(1).GetComponent<Text>().text = "Idiot Crown";
                AudioSourceefect.clip = NewItemAudio;
                AudioSourceefect.Play();
                break;
            case 1:
                PanelNewItemPanel.transform.GetChild(0).GetComponent<Image>().sprite = ItemSprites[1];
                PanelNewItemPanel.transform.GetChild(1).GetComponent<Text>().text = "Magnet";
                AudioSourceefect.clip = NewItemAudio;
                AudioSourceefect.Play();
                break;
            case 2:
                PanelNewItemPanel.transform.GetChild(0).GetComponent<Image>().sprite = ItemSprites[2];
                PanelNewItemPanel.transform.GetChild(1).GetComponent<Text>().text = "Fire";
                AudioSourceefect.clip = NewItemAudio;
                AudioSourceefect.Play();
                break;
        }
        yield return new WaitForSeconds(3.5f);
        PanelNewItemPanel.SetActive(false);
    }
    public void MiciferScene01()
    {
        MiciferState = PlayerPrefs.GetInt("MiciferState");
        switch (MiciferState)
        {
            case 1:
                DialogText = "Whoa! you really bought 1 coin for 5 coins..... Smart!!!";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.SetInt("CoinsNext", 2);
                PlayerPrefs.Save();
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                break;
            case 2:
                DialogText = "I can see you are good at bussines!!";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.SetInt("CoinsNext", 1);
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                PlayerPrefs.Save();
                break;
            case 3:
                DialogText = "It suits you!!";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.SetInt("Crown", 1);
                StartCoroutine(PanelNewItem(0));
                PlayerPrefs.Save();
                Crown.SetActive(true);
                player.MULTIPLAYER = 2;
                PlayerPrefs.SetInt("CoinsNext", 3);
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                break;

               
            case 4:
                DialogText = "Keep Coming for more King! :)";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.SetInt("CoinsNext", 2);
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                PlayerPrefs.Save();
                break;
            case 5:
                DialogText = "Are you sure this is the best for you?.....";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("CoinsNext", 1);
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.Save();
                break;
            case 6:
                DialogText = "You defenetly call the money now!!";
                MiciferState++;
                DialogTextBox.text = DialogText;
                Magnet.SetActive(true);
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                StartCoroutine(PanelNewItem(1));
                PlayerPrefs.SetInt("Magnet", 1);
                PlayerPrefs.SetInt("CoinsNext", 3);
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                PlayerPrefs.Save();
                break;
          
            case 7:
                DialogText = "Shark Mentality I can see!";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.SetInt("CoinsNext", 2);
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                PlayerPrefs.Save();
                break;
            case 8:
                DialogText = "Keep Geting RICHERRR!!!";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.SetInt("CoinsNext", 1);
                CoinsToItem.SetActive(true);
                CoinsToItem.GetComponent<Text>().text = "Coins to next item: " + PlayerPrefs.GetInt("CoinsNext").ToString();
                PlayerPrefs.Save();

                break;
            case 9:
                DialogText = "You are on fire!";
                MiciferState++;
                DialogTextBox.text = DialogText;
                PlayerPrefs.SetInt("MiciferState", MiciferState);
                PlayerPrefs.SetInt("Fire", 1);
                CoinsToItem.SetActive(true);
                Fire.SetActive(true);
                StartCoroutine(PanelNewItem(2));
                CoinsToItem.GetComponent<Text>().text = "No more Items :(";
                PlayerPrefs.Save();

                break;

        }

    }


}
