using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    string _androidGameid;
    string _GameId = "5127931";
    string placementId;

    public void Awake()
    {

        _androidGameid = "Rewarded_Android";
        placementId = _androidGameid;
        Advertisement.Initialize(_GameId,this);
       // Advertisement.AddListener(this);
        Debug.Log("StaratAdsState: " + Advertisement.isInitialized);

    }

   
    public void OnInitializationComplete()
    {
        Debug.Log("Los anuncios se iniciaron correctamnete");
        LoadAdd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Los anuncios NO se iniciaron correctamnete");
    }

   public void LoadAdd()
    {
        Advertisement.Load(_androidGameid, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("AD ERROR");
    }




    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Los anuncios NO se MOSTARON correctamnete");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Los anuncios NO se INICIARON correctamnete");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Los anuncios NO se CLIKEARON correctamnete");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("REWARD!");
    }
}