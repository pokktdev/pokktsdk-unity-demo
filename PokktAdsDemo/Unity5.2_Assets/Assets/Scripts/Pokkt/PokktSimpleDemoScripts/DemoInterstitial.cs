using UnityEngine;
using UnityEngine.UI;
using Pokkt;

public class DemoInterstitial : MonoBehaviour
{
	// exposed properties
	public GameObject ScreenManagerGO;

	public Text PointsEarned;
	public Text StatusMessage;
	public Text ScreenName;
	public Button CacheRewardedAd;
	public Button CacheNonRewardedAd;
	public Button ShowRewardedAd;
	public Button ShowNonRewardedAd;

	// internal states
	private bool _listenerAttached;
	private float _totalRewardAmount;

	void Awake()
	{
		// handle pokkt interstitial events
		if (!_listenerAttached)
		{
			PokktAds.Interstitial.AdAvailabilityEvent += OnAdAvailability;
			PokktAds.Interstitial.AdCachingCompletedEvent += OnAdCached;
			PokktAds.Interstitial.AdCachingFailedEvent += OnAdCachingFailed;
			PokktAds.Interstitial.AdDisplayedEvent += OnAdDisplayed;
			PokktAds.Interstitial.AdFailedToShowEvent += OnAdFailedToShow;
			PokktAds.Interstitial.AdSkippedEvent += OnAdSkipped;
			PokktAds.Interstitial.AdCompletedEvent += OnAdCompleted;
			PokktAds.Interstitial.AdClosedEvent += OnAdClosed;
			PokktAds.Interstitial.AdGratifiedEvent += OnAdGratified;

			_listenerAttached = true;
		}
	}

	private void OnAdAvailability(string screenName, bool isRewarded, bool isAvailable)
	{
		if (screenName != ScreenName.text)
			return;
		
		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial for "
		                + screenName + ", is " + (isAvailable ? "available!" : "not available!"));

		// NOTE: you have been notified about the ad availability, 
		// this does not say anything about whether an ad is cached or not,
		// listen to AdCachingCompletedEvent for ad caching notification.
	}

	private void OnAdCached(string screenName, bool isRewarded, float vc)
	{
		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial is cached for "
		          + screenName + ", associated vc is " + vc);

		if (screenName != ScreenName.text)
			return;

		StatusMessage.text = "interstitial cached!";
		
		if (isRewarded)
		{
			CacheRewardedAd.GetComponentInChildren<Text>().text = "rewarded interstitial is cached!";
			ShowRewardedAd.GetComponentInChildren<Text>().text = "Show Rewarded Ad (Cached)";
			ShowRewardedAd.interactable = true;
		}
		else
		{
			CacheNonRewardedAd.GetComponentInChildren<Text>().text = "non-rewarded interstitial is cached!";
			ShowNonRewardedAd.GetComponentInChildren<Text>().text = "Show Non-Rewarded Ad (Cached)";
			ShowNonRewardedAd.interactable = true;
		}
	}
	
	private void OnAdCachingFailed(string screenName, bool isRewarded, string message)
	{
		if (screenName != ScreenName.text)
			return;

		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial caching failed for "
		                + screenName + "! message: " + message);
		
		if (isRewarded)
		{
			CacheRewardedAd.GetComponentInChildren<Text>().text = "Cache Rewarded Ad";
			ShowRewardedAd.GetComponentInChildren<Text>().text = "Show Rewarded Ad";
			CacheRewardedAd.interactable = true;
			ShowRewardedAd.interactable = true;
		}
		else
		{
			CacheNonRewardedAd.GetComponentInChildren<Text>().text = "Cache Non-Rewarded Ad";
			ShowNonRewardedAd.GetComponentInChildren<Text>().text = "Show Non-Rewarded Ad";
			CacheNonRewardedAd.interactable = true;
			ShowNonRewardedAd.interactable = true;
		}
	}
	
	private void OnAdDisplayed(string screenName, bool isRewarded)
	{
		if (screenName != ScreenName.text)
			return;

		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial is displayed for " + screenName + "!");
		
		if (isRewarded)
		{
			CacheRewardedAd.interactable = false;
			ShowRewardedAd.interactable = false;
		}
		else
		{
			CacheNonRewardedAd.interactable = false;
			ShowNonRewardedAd.interactable = false;
		}
	}

	private void OnAdFailedToShow(string screenName, bool isRewarded, string message)
	{
		if (screenName != ScreenName.text)
			return;

		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial failed to show for "
			+ screenName + "! message: " + message);

		if (isRewarded)
		{
			CacheRewardedAd.GetComponentInChildren<Text>().text = "Cache Rewarded Ad";
			ShowRewardedAd.GetComponentInChildren<Text>().text = "Show Rewarded Ad";
			CacheRewardedAd.interactable = true;
			ShowRewardedAd.interactable = true;
		}
		else
		{
			CacheNonRewardedAd.GetComponentInChildren<Text>().text = "Cache Non-Rewarded Ad";
			ShowNonRewardedAd.GetComponentInChildren<Text>().text = "Show Non-Rewarded Ad";
			CacheNonRewardedAd.interactable = true;
			ShowNonRewardedAd.interactable = true;
		}
	}

	private void OnAdCompleted(string screenName, bool isRewarded)
	{
		if (screenName != ScreenName.text)
			return;

		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial is completed for " + screenName + "!");
	}
	
	private void OnAdSkipped(string screenName, bool isRewarded)
	{
		if (screenName != ScreenName.text)
			return;

		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial is skipped for " + screenName + "!");
	}
	
	private void OnAdClosed(string screenName, bool isRewarded)
	{
		if (screenName != ScreenName.text)
			return;
		
		Debug.Log((isRewarded ? "rewarded" : "non-rewarded") + " interstitial is closed for " + screenName + "!");
		
		if (isRewarded)
		{
			CacheRewardedAd.interactable = true;
			ShowRewardedAd.interactable = true;
			CacheRewardedAd.GetComponentInChildren<Text>().text = "Cache Rewarded Ad";
			ShowRewardedAd.GetComponentInChildren<Text>().text = "Show Rewarded Ad";
		}
		else
		{
			CacheNonRewardedAd.interactable = true;
			ShowNonRewardedAd.interactable = true;
			CacheNonRewardedAd.GetComponentInChildren<Text>().text = "Cache Non-Rewarded Ad";
			ShowNonRewardedAd.GetComponentInChildren<Text>().text = "Show Non-Rewarded Ad";
		}
	}
	
	private void OnAdGratified(string screenName, float reward)
	{
		if (screenName != ScreenName.text)
			return;

		Debug.Log("interstitial for " + screenName + " is gratified! reward received: " + reward);
		_totalRewardAmount += reward;
		PointsEarned.text = "Ad VC: " + _totalRewardAmount;
	}

	void Start()
	{
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ScreenManagerGO.GetComponent<ScreenManager>().OpenScreen("DemoSelectorScreen");
		}
	}

	//interstitial calls
	public void OnClickCacheRewardedAd()
	{
		CacheRewardedAd.interactable = false;
		ShowRewardedAd.interactable = false;
		CacheRewardedAd.GetComponentInChildren<Text>().text = "rewarded ad is downloading...";
		ShowRewardedAd.GetComponentInChildren<Text>().text = "rewarded ad is downloading...";
		
		// request pokkt-sdk for a rewarded ad to be cached
		PokktAds.Interstitial.CacheRewarded (ScreenName.text);
	}
	
	public void OnClickCacheNonRewardedAd()
	{
		CacheNonRewardedAd.interactable = false;
		ShowNonRewardedAd.interactable = false;
		CacheNonRewardedAd.GetComponentInChildren<Text>().text = "non-rewarded ad is downloading...";
		ShowNonRewardedAd.GetComponentInChildren<Text>().text = "non-rewarded ad is downloading...";
		
		// request pokkt-sdk for a non-rewarded ad to be cached
		PokktAds.Interstitial.CacheNonRewarded(ScreenName.text);
	}
	
	public void OnClickShowRewardedAd()
	{
		// request pokkt-sdk to show a rewarded ad
		PokktAds.Interstitial.ShowRewarded(ScreenName.text);
	}
	
	public void OnClickShowNonRewardedAd()
	{
		// request pokkt-sdk to show a non-rewarded ad
		PokktAds.Interstitial.ShowNonRewarded(ScreenName.text);
	}

	public void ExportLog()
	{
		PokktAds.Debugging.ExportLog();
	}
}
