using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour {
    
    public static AdController instance;
    private string store_id = "2994503";
    private string placementVideoId = "video";
    private void Awake()
    {
        if (AdController.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start () {
        Monetization.Initialize(store_id,false);
	}

    public void ShowVideoAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }
    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementVideoId))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementVideoId) as ShowAdPlacementContent;
        if (ad != null) {
            ad.Show();
        }
    }

    public void CancelAdLoadOnRetry()
    {
        StopAllCoroutines();
    }
}
