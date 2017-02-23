using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Pokkt;

public class SimpleDemoSelector : MonoBehaviour
{
	public GameObject ScreenManagerGO = null;
	public Button DemoScreen1 = null;
	public Button DemoScreen2 = null;
	public Button DemoBanner = null;

	void Awake ()
	{
		PokktAds.Banner.BannerLoadedEvent += OnBannerLoaded;
		PokktAds.Banner.BannerLoadFailedEvent += OnBannerLoadFailed;
	}
	
	void Start ()
	{
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	private void OnBannerLoaded(string screenName)
	{
		Debug.Log("banner loaded for screen: " + screenName);
		// TODO
	}

	private void OnBannerLoadFailed(string screenName, string message)
	{
		Debug.Log("banner load failed for screen: " + screenName + ", message: " + message);
		// TODO
	}

	public void StartVideoAdDemo()
	{
		ScreenManagerGO.GetComponent<ScreenManager>().OpenScreen("DemoVideoAd");
	}

	public void StartInterstitialDemo()
	{

		ScreenManagerGO.GetComponent<ScreenManager>().OpenScreen("DemoInterstitial");
	}
	
	public void StartBannerDemo()
	{
		PokktAds.Banner.ShouldAutoRefresh(true);
		PokktAds.Banner.LoadBanner("UnityDemoBannerAndroid", (int)BannerPosition.BottomCenter);
		//PokktManager.LoadBannerWithRect("UnityDemoBannerAndroid",50,300,100,100);
		//PokktManager.BannerAutoRefresh(true);

		// TODO:
		//ScreenManagerGO.GetComponent<ScreenManager>().OpenScreen("DemoBanner");
	}
	
	public void ExportLog()
	{
		PokktAds.Debugging.ExportLog();
	}
}
