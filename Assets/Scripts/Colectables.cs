using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Colectables : MonoBehaviour
{
    public GameObject[] Coletables;
    int Crown, Magnet, Fire;
    // Start is called before the first frame update
    void Start()
    {
     
        Crown = PlayerPrefs.GetInt("Crown");
        Magnet = PlayerPrefs.GetInt("Magnet");
        Fire = PlayerPrefs.GetInt("Fire");
        if(Magnet > 0)
        {
            Coletables[1].GetComponent<Image>().color = Color.white;
            Coletables[1].transform.GetChild(0).gameObject.SetActive(false);
        }
        if (Crown> 0)
        {
            Coletables[0].GetComponent<Image>().color = Color.white;
            Coletables[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        if (Fire > 0)
        {
            Coletables[2].GetComponent<Image>().color = Color.white;
            Coletables[2].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
