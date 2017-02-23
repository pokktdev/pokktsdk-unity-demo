using UnityEngine;
using System;
using System.Collections;
using Pokkt.Models;

namespace Pokkt
{
	public static class PokktAds
	{
		/**
	     * Pokkt GO
	     **/
		private const string PokktAdsGOName = "PokktAdsGO";

		// internal state
		private static GameObject _pokktAdsGO;

		private static void CheckAndInitDispatcher()
		{
			// check for any existing dispatcher go
			_pokktAdsGO = GameObject.Find(PokktAdsGOName);

			// if it does not exists, create one
			if (_pokktAdsGO == null)
			{
				// create a game object to listen to messages from java
				_pokktAdsGO = new GameObject(PokktAdsGOName);

				// retain this object
				GameObject.DontDestroyOnLoad(_pokktAdsGO);
			}

			// attach the dispatcher sript component to it, if not available already
			if (_pokktAdsGO.GetComponent<PokktAdsGO>() == null)
				_pokktAdsGO.AddComponent<PokktAdsGO>();
		}

		public static PokktAdsGO Dispatcher
		{
			get
			{
				// keep checking for dispatcher
				CheckAndInitDispatcher();
				return _pokktAdsGO.GetComponent<PokktAdsGO>();
			}
		}

		public static GameObject DispatcherGO()
		{
			return _pokktAdsGO;
		}


		/**
	     * Common APIs
	     **/
		public static void SetPokktConfig(string appId, string securityKey)
		{
			// this initializes pokkt go, ignore this variable
			PokktAdsGO go = Dispatcher;
			if (go == null)
				return;

			JSONObject configObj = new JSONObject();
			configObj.AddField("appId", appId);
			configObj.AddField("securityKey", securityKey);

			PokktNativeExtension.NotifyNative("setPokktConfig", configObj.ToString());
		}

		public static void SetThirdPartyUserId(string userId)
		{
			PokktNativeExtension.NotifyNative("setThirdPartyUserId", userId);
		}

		public static void SetAdPlayerViewConfig(PokktAdPlayerViewConfig adPlayerViewConfig)
		{
			JSONObject jo = new JSONObject();
			jo.AddField("shouldAllowSkip", adPlayerViewConfig.ShouldAllowSkip);
			jo.AddField("defaultSkipTime", adPlayerViewConfig.DefaultSkipTime);
			jo.AddField("skipConfirmMessage", adPlayerViewConfig.SkipConfirmMessage);
			jo.AddField("backButtonDisabled", adPlayerViewConfig.BackButtonDisabled);
			jo.AddField("shouldSkipConfirm", adPlayerViewConfig.ShouldConfirmSkip);
			jo.AddField("skipConfirmYesLabel", adPlayerViewConfig.SkipConfirmYesLabel);
			jo.AddField("skipConfirmNoLabel", adPlayerViewConfig.SkipConfirmNoLabel);
			jo.AddField("skipTimerMessage", adPlayerViewConfig.SkipTimerMessage);
			jo.AddField("incentiveMessage", adPlayerViewConfig.IncentiveMessage);

			PokktNativeExtension.NotifyNative("setCustomAdPlayerViewConfig", jo.ToString());
		}

		public static void SetUserDetails(PokktUserDetails userDetails)
		{
			JSONObject jo = new JSONObject();
			jo.AddField("name", userDetails.Name);
			jo.AddField("age", userDetails.Age);
			jo.AddField("sex", userDetails.Sex);
			jo.AddField("mobileNo", userDetails.MobileNo);
			jo.AddField("emailAddress", userDetails.EmailAddress);
			jo.AddField("location", userDetails.Location);
			jo.AddField("birthday", userDetails.Birthday);
			jo.AddField("maritalStatus", userDetails.MaritalStatus);
			jo.AddField("facebookId", userDetails.FacebookId);
			jo.AddField("twitterHandle", userDetails.TwitterHandle);
			jo.AddField("education", userDetails.Education);
			jo.AddField("nationality", userDetails.Nationality);
			jo.AddField("employment", userDetails.Employment);
			jo.AddField("maturityRating", userDetails.MaturityRating);

			PokktNativeExtension.NotifyNative("setCustomAdPlayerViewConfig", jo.ToString());
		}
			
		public static string GetPokktSDKVersion()
		{
			return PokktNativeExtension.GetSdkVersion();
		}


		/**
	     * Video Ads APIs
	     **/
		public static class VideoAd
		{
			public static event Action<string, bool, float> AdCachingCompletedEvent;
			public static event Action<string, bool, string> AdCachingFailedEvent;
			public static event Action<string, bool> AdDisplayedEvent;
			public static event Action<string, bool, string> AdFailedToShowEvent;
			public static event Action<string, bool> AdSkippedEvent;
			public static event Action<string, bool> AdCompletedEvent;
			public static event Action<string, bool> AdClosedEvent;
			public static event Action<string, float> AdGratifiedEvent;
			public static event Action<string, bool, bool> AdAvailabilityEvent;

			public static void CacheRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("VideoAd.cacheRewarded", screenName);
			}

			public static void ShowRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("VideoAd.showRewarded", screenName);
			}

			public static void CacheNonRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("VideoAd.cacheNonRewarded", screenName);
			}

			public static void ShowNonRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("VideoAd.showNonRewarded", screenName);
			}

			public static void CheckAdAvailability(string screenName, bool isRewarded)
			{
				string operation = isRewarded ? "VideoAd.checkAdAvailability.rewarded" : "VideoAd.checkAdAvailability.nonRewarded";
				PokktNativeExtension.NotifyNative(operation, screenName);
			}

			// invokers
			public static void InvokeAdCachingCompletedEvent(string screenName, bool isRewarded, float reward)
			{
				if (AdCachingCompletedEvent != null)
					AdCachingCompletedEvent(screenName, isRewarded, reward);
			}

			public static void InvokeAdCachingFailedEvent(string screenName, bool isRewarded, string errorMessage)
			{
				if (AdCachingFailedEvent != null)
					AdCachingFailedEvent(screenName, isRewarded, errorMessage);
			}

			public static void InvokeAdDisplayedEvent(string screenName, bool isRewarded)
			{
				if (AdDisplayedEvent != null)
					AdDisplayedEvent(screenName, isRewarded);
			}

			public static void InvokeAdFailedToShowEvent(string screenName, bool isRewarded, string errorMessage)
			{
				if (AdFailedToShowEvent != null)
					AdFailedToShowEvent(screenName, isRewarded, errorMessage);
			}

			public static void InvokeAdSkippedEvent(string screenName, bool isRewarded)
			{
				if (AdSkippedEvent != null)
					AdSkippedEvent(screenName, isRewarded);
			}

			public static void InvokeAdCompletedEvent(string screenName, bool isRewarded)
			{
				if (AdCompletedEvent != null)
					AdCompletedEvent(screenName, isRewarded);
			}

			public static void InvokeAdClosedEvent(string screenName, bool isRewarded)
			{
				if (AdClosedEvent != null)
					AdClosedEvent(screenName, isRewarded);
			}

			public static void InvokeAdGratifiedEvent(string screenName, float reward)
			{
				if (AdGratifiedEvent != null)
					AdGratifiedEvent(screenName, reward);
			}

			public static void InvokeAdAvailabilityEvent(string screenName, bool isRewarded, bool isAvailable)
			{
				if (AdAvailabilityEvent != null)
					AdAvailabilityEvent(screenName, isRewarded, isAvailable);
			}
		}


		/**
	     * Interstitial APIs
	     **/
		public static class Interstitial
		{
			public static event Action<string, bool, float> AdCachingCompletedEvent;
			public static event Action<string, bool, string> AdCachingFailedEvent;
			public static event Action<string, bool> AdDisplayedEvent;
			public static event Action<string, bool, string> AdFailedToShowEvent;
			public static event Action<string, bool> AdSkippedEvent;
			public static event Action<string, bool> AdCompletedEvent;
			public static event Action<string, bool> AdClosedEvent;
			public static event Action<string, float> AdGratifiedEvent;
			public static event Action<string, bool, bool> AdAvailabilityEvent;

			public static void CacheRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("Interstitial.cacheRewarded", screenName);
			}

			public static void ShowRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("Interstitial.showRewarded", screenName);
			}

			public static void CacheNonRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("Interstitial.cacheNonRewarded", screenName);
			}

			public static void ShowNonRewarded(string screenName)
			{
				PokktNativeExtension.NotifyNative("Interstitial.showNonRewarded", screenName);
			}

			public static void CheckAdAvailability(string screenName, bool isRewarded)
			{
				string operation = isRewarded ? "Interstitial.checkAdAvailability.rewarded" : "Interstitial.checkAdAvailability.nonRewarded";
				PokktNativeExtension.NotifyNative(operation, screenName);
			}

			// invokers
			public static void InvokeAdCachingCompletedEvent(string screenName, bool isRewarded, float reward)
			{
				if (AdCachingCompletedEvent != null)
					AdCachingCompletedEvent(screenName, isRewarded, reward);
			}

			public static void InvokeAdCachingFailedEvent(string screenName, bool isRewarded, string errorMessage)
			{
				if (AdCachingFailedEvent != null)
					AdCachingFailedEvent(screenName, isRewarded, errorMessage);
			}

			public static void InvokeAdDisplayedEvent(string screenName, bool isRewarded)
			{
				if (AdDisplayedEvent != null)
					AdDisplayedEvent(screenName, isRewarded);
			}

			public static void InvokeAdFailedToShowEvent(string screenName, bool isRewarded, string errorMessage)
			{
				if (AdFailedToShowEvent != null)
					AdFailedToShowEvent(screenName, isRewarded, errorMessage);
			}

			public static void InvokeAdSkippedEvent(string screenName, bool isRewarded)
			{
				if (AdSkippedEvent != null)
					AdSkippedEvent(screenName, isRewarded);
			}

			public static void InvokeAdCompletedEvent(string screenName, bool isRewarded)
			{
				if (AdCompletedEvent != null)
					AdCompletedEvent(screenName, isRewarded);
			}

			public static void InvokeAdClosedEvent(string screenName, bool isRewarded)
			{
				if (AdClosedEvent != null)
					AdClosedEvent(screenName, isRewarded);
			}

			public static void InvokeAdGratifiedEvent(string screenName, float reward)
			{
				if (AdGratifiedEvent != null)
					AdGratifiedEvent(screenName, reward);
			}

			public static void InvokeAdAvailabilityEvent(string screenName, bool isRewarded, bool isAvailable)
			{
				if (AdAvailabilityEvent != null)
					AdAvailabilityEvent(screenName, isRewarded, isAvailable);
			}
		}


		/**
		 * Banner APIs
		 **/
		public static class Banner
		{
			public static event Action<string> BannerLoadedEvent;
			public static event Action<string, string> BannerLoadFailedEvent;

			public static void LoadBanner(string screenName, int position)
			{
				JSONObject jo = new JSONObject();
				jo.AddField("screenName", screenName);
				jo.AddField("bannerPosition", position);

				PokktNativeExtension.NotifyNative("Banner.loadBanner", jo.ToString());	
			}

			public static void LoadBannerWithRect(string screenName, int height, int width, float x, float y)
			{
				JSONObject jo = new JSONObject();
				jo.AddField("screenName", screenName);
				jo.AddField("width", width);
				jo.AddField("height", height);
				jo.AddField("x", x);
				jo.AddField("y", y);

				PokktNativeExtension.NotifyNative("Banner.loadBannerWithRect", jo.ToString());	
			}

			public static void RemoveBanner()
			{
				PokktNativeExtension.NotifyNative("Banner.destroyBanner");	
			}

			public static void ShouldAutoRefresh(bool refresh)
			{
				PokktNativeExtension.NotifyNative("Banner.shouldAutoRefresh", (refresh ? "true" : "false"));	
			}

			// invokers
			public static void InvokeBannerLoadedEvent(string screenName)
			{
				if (BannerLoadedEvent != null)
					BannerLoadedEvent(screenName);
			}

			public static void InvokeBannerLoadFailedEvent(string screenName, string errorMessage)
			{
				if (BannerLoadFailedEvent != null)
					BannerLoadFailedEvent(screenName, errorMessage);
			}
		}


		/**
	     * IGA APIs
	     **/
		public static class InGameAd
		{
			public static event Action IGAAssetsReadyEvent;
			public static event Action<string> IGAAssetsFailedEvent;

			public static void FetchAssets(string screenName)
			{
				PokktNativeExtension.NotifyNative("InGameAd.fetchAssets", screenName);
			}

			// invokers
			public static void InvokeIGAAssetsReadyEvent()
			{
				if (IGAAssetsReadyEvent != null)
					IGAAssetsReadyEvent();
			}

			public static void InvokeIGAAssetsFailedEvent(string errorMessage)
			{
				if (IGAAssetsFailedEvent != null)
					IGAAssetsFailedEvent(errorMessage);
			}
		}


		/**
	     * Analytics and Session APIs
	     **/
		public static class Analytics
		{
			public static void SetAnalyticsDetails(AnalyticsDetails analyticsDetails) 
			{
				JSONObject jo = new JSONObject();
				jo.AddField("googleAnalyticsID", analyticsDetails.GoogleAnalyticsId);
				jo.AddField("mixPanelProjectToken", analyticsDetails.MixPanelProjectToken);
				jo.AddField("flurryApplicationKey", analyticsDetails.FlurryApplicationKey);
				jo.AddField("selectedAnalyticsType", analyticsDetails.SelectedAnalyticsType); // TODO: define type

				PokktNativeExtension.NotifyNative("Analytics.setAnalyticsDetails", jo.ToString());
			}

			public static void trackIAP(InAppPurchaseDetails details)
			{
				JSONObject jo = new JSONObject();

				jo.AddField("productId", details.ProductId);
				jo.AddField("price", details.Price);
				jo.AddField("currencyCode", details.CurrencyCode);
				jo.AddField("title", details.Title);
				jo.AddField("description", details.Description);
				jo.AddField("purchaseData", details.PurchaseData);
				jo.AddField("purchaseSignature", details.PurchaseSignature);
				jo.AddField("purchaseStore", details.PurchaseStore);

				PokktNativeExtension.NotifyNative("Analytics.trackIAP", jo.ToString());
			}

			public static void NotifyAppInstall()
			{
				PokktNativeExtension.NotifyNative("Analytics.notifyAppInstall");
			}

			public static void UpdateIGAData(string data)
			{
				PokktNativeExtension.NotifyNative("Analytics.updateIGAData", data);
			}
		}


		/**
	     * Debugging APIs
	     **/
		public static class Debugging
		{
			public static void ShouldDebug(bool value)
			{
				PokktNativeExtension.NotifyNative("Debugging.shouldDebug", (value ? "true" : "false"));
			}

			public static void ExportLog()
			{
				PokktNativeExtension.NotifyNative("Debugging.exportLog", "");
			}

			public static void ExportLogToCloud()
			{
				PokktNativeExtension.NotifyNative("Debugging.exportLogToCloud", "");
			}

			public static void ShowToast(string message)
			{
				PokktNativeExtension.NotifyNative("Debugging.showToast", "");
			}

			public static void ShowLog(string message)
			{
				PokktNativeExtension.NotifyNative("Debugging.showLog", message);
			}
		}
	}
}