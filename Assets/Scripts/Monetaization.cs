using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class Monetaization : MonoBehaviour, IUnityAdsListener, IUnityAdsLoadListener
{

    PlayerController Player;
    public Button RewardButton;
   // public GameObject Noadds;
    bool OnloadAdd = true;

    string RewardedAd = "Rewarded_Android";
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        Advertisement.Initialize("5127931");
        Advertisement.AddListener(this);
        Advertisement.Load(RewardedAd, this);
    }

  public void RewardAd()
    {
        if(Advertisement.IsReady(RewardedAd))
        {
          
            Advertisement.Show(RewardedAd);
            Player.ONadd = false;
            OnloadAdd = false;
            
        }
        else
        {
            Debug.Log("AdNotReady");
       
          
            StartCoroutine(RepeatAdd());
        }
    }
 
    IEnumerator RepeatAdd()
    {
        Advertisement.Load(RewardedAd);


        yield return new WaitForSeconds(1);
        if (Advertisement.IsReady(RewardedAd))
        {

            Advertisement.Show(RewardedAd);
            Player.ONadd = false;
            OnloadAdd = false;

        }
            }
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADisReady");
        if(OnloadAdd == true)
        {
            RewardButton.interactable = true;
        }
     
       // Noadds.SetActive(false);
        //  throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ADError");
      //  throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("ADisStarted");
      //  throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == RewardedAd && showResult == ShowResult.Finished)
        {
            Debug.Log("Revivir");
            GameObject.Find("DeathPanel").SetActive(false);
            // Player.DeathPanel.SetActive(false);
            if (Player == null)
            {
                Debug.Log("Player Not Found");
                GameObject.Find("Player").GetComponent<PlayerController>().TimeToRevive();
            }
            else
            {
                Player.TimeToRevive();
            }


        }
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Buenardo :)");
     //   Noadds.SetActive(false);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Perroski :(");
        Player.ONadd = true;
    }

    public void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }

}
