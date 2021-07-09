using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsControl : MonoBehaviour
{
    public InterstitialAd interstitial;

    static AdsControl reklamKontrol;


    public void Awake()
    {

        if (reklamKontrol == null)
        {
            DontDestroyOnLoad(gameObject);
            reklamKontrol = this;
            MobileAds.Initialize(initStatus => { });

            RequestInterstitial();
        }
        else
        {
            Destroy(gameObject);
        }
            

           
        

        
    }

    public void Start()
    {
        
    }


    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

    }

    

    

    public void showAds1()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        reklamKontrol = null;
        Destroy(gameObject);
        
    }

   


}
