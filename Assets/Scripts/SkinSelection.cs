using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelection : MonoBehaviour
{
    public GameObject Player;
    public Image UiPlayer01, UiPlayer02;
    public GameObject[] SkinButtons;
    public Sprite[] PlayerSprites;
    public Animator PlayerAnimator;

    int SkinSelectionNumber, SaveSkinSlection;
    int SkinUnlock01, SkinUnlock02, SkinUnlock03, SkinUnlock04, SkinUnlock05, SkinUnlock06;
    void Start()
    {
        SaveSkinSlection = PlayerPrefs.GetInt("SaveSkin");

        SkinUnlock01 = PlayerPrefs.GetInt("SkinUnlock01");
        SkinUnlock02 = PlayerPrefs.GetInt("SkinUnlock02");
        SkinUnlock03 = PlayerPrefs.GetInt("SkinUnlock03");
        SkinUnlock04 = PlayerPrefs.GetInt("SkinUnlock04");
        SkinUnlock05 = PlayerPrefs.GetInt("SkinUnlock05");
        SkinUnlock06 = PlayerPrefs.GetInt("SkinUnlock06");

        Debug.Log(SkinUnlock01);
        Debug.Log(SkinUnlock02);
        if (SkinUnlock01 > 0)
        {
            SkinButtons[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            SkinButtons[0].transform.GetChild(0).transform.gameObject.SetActive(false);
            SkinButtons[0].GetComponent<Button>().enabled = true;
        }
        if (SkinUnlock02 > 0)
        {
            SkinButtons[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            SkinButtons[1].transform.GetChild(0).transform.gameObject.SetActive(false);
            SkinButtons[1].GetComponent<Button>().enabled = true;
        }
        if (SkinUnlock03 > 0)
        {
            SkinButtons[2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            SkinButtons[2].transform.GetChild(0).transform.gameObject.SetActive(false);
            SkinButtons[2].GetComponent<Button>().enabled = true;
        }
        if (SkinUnlock04 > 0)
        {
            SkinButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            SkinButtons[3].transform.GetChild(0).transform.gameObject.SetActive(false);
            SkinButtons[3].GetComponent<Button>().enabled = true;
        }
        if (SkinUnlock05 > 0)
        {
            SkinButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            SkinButtons[4].transform.GetChild(0).transform.gameObject.SetActive(false);
            SkinButtons[4].GetComponent<Button>().enabled = true;
        }
        if (SkinUnlock06 > 0)
        {
            SkinButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            SkinButtons[5].transform.GetChild(0).transform.gameObject.SetActive(false);
            SkinButtons[5].GetComponent<Button>().enabled = true;
        }

        SavedSkin();
    }

    // Update is called once per frame

    public void SkinSelector(int SkinType)
    {
        SkinSelectionNumber = SkinType;
        PlayerAnimator.SetInteger("SkinsSelection", SkinType);
        PlayerPrefs.SetInt("SaveSkin", SkinType);
        PlayerPrefs.Save();
        UiPlayer01.sprite = PlayerSprites[SkinType];
        UiPlayer02.sprite = PlayerSprites[SkinType];
        Player.GetComponent<TrailEfect>().Skinvalue = SkinType;
    }

    void SavedSkin()
    {
        int SkinType = PlayerPrefs.GetInt("SaveSkin");
        PlayerAnimator.SetInteger("SkinsSelection", SkinType);
        UiPlayer01.sprite = PlayerSprites[SkinType];
        UiPlayer02.sprite = PlayerSprites[SkinType];
        Player.GetComponent<TrailEfect>().Skinvalue = SkinType;
    }
}
