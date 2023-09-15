using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    int OnLoad = 1;
    public GameObject[]Menus;

    public void Selection(int Direcction)
    {
        switch(Direcction)
        {
            case 1:
                OnLoad++;
                break;
            case 0:
                OnLoad--;
                break;

        }    
    }

    void Rotation()

    {
        switch(OnLoad)
        {
            case 0:
                OnLoad = 4;
                break;
            case 1:
                Menus[0].SetActive(true);
                Menus[1].SetActive(false);
                Menus[3].SetActive(false);
                break;
            case 2:
                Menus[0].SetActive(false);
                Menus[1].SetActive(true);
                Menus[2].SetActive(false);
                break;
            case 3:
                Menus[0].SetActive(false);
                Menus[1].SetActive(false);
                Menus[2].SetActive(true);
                Menus[3].SetActive(false);
                break;
            case 4:
                Menus[0].SetActive(false);
                Menus[2].SetActive(false);
                Menus[3].SetActive(true);
                break;
            case 5:
                OnLoad = 1;
                break;
        }
    }

    private void Update()
    {
        Rotation();
    }




}
