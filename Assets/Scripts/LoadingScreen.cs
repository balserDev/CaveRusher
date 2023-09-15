using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadinScreenPanel;
    public GameObject StartPanel;

    public void LoadinScreen()
    {
        StartCoroutine(PanelLoading());

    }
    IEnumerator PanelLoading()
    {
        LoadinScreenPanel.SetActive(true);
        yield return new WaitForSeconds(4.3f);
        StartPanel.SetActive(false);
        LoadinScreenPanel.SetActive(false);
     
    }
}
