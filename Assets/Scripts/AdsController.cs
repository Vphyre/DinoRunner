using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour
{
    public string ad;
    private bool showed;
    // Start is called before the first frame update
    void Start()
    {
       Advertisement.Initialize("4373555");
       showed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!showed)
        {
            ShowAd();
        }
        
    }
    void ShowAd()
    {
       if(Advertisement.IsReady(ad))
       {
            Advertisement.Show(ad);
            showed = true;
       }
    }
}
