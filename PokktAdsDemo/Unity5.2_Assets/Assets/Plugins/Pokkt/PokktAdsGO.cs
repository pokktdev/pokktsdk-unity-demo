using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Pokkt;
using Pokkt.IGA;

public class PokktAdsGO : MonoBehaviour
{
	/**
	 * Ads Delegates
	 **/
	public void AdCachingCompleted(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		float reward;
		float.TryParse(parameters ["REWARD"], out reward);

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdCachingCompletedEvent(screenName, isRewarded, reward);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdCachingCompletedEvent(screenName, isRewarded, reward);
			break;
		}
	}

	public void AdCachingFailed(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		string errorMessage = parameters ["ERROR_MESSAGE"];

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdCachingFailedEvent(screenName, isRewarded, errorMessage);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdCachingFailedEvent(screenName, isRewarded, errorMessage);
			break;
		}
	}

	public void AdDisplayed(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdDisplayedEvent(screenName, isRewarded);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdDisplayedEvent(screenName, isRewarded);
			break;
		}
	}

	public void AdFailedToShow(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		string errorMessage = parameters ["ERROR_MESSAGE"];

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdFailedToShowEvent(screenName, isRewarded, errorMessage);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdFailedToShowEvent(screenName, isRewarded, errorMessage);
			break;
		}
	}

	public void AdClosed(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdClosedEvent(screenName, isRewarded);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdClosedEvent(screenName, isRewarded);
			break;
		}
	}

	public void AdSkipped(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdSkippedEvent(screenName, isRewarded);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdSkippedEvent(screenName, isRewarded);
			break;
		}
	}

	public void AdCompleted(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdCompletedEvent(screenName, isRewarded);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdCompletedEvent(screenName, isRewarded);
			break;
		}
	}

	public void AdGratified(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		float reward;
		float.TryParse(parameters ["REWARD"], out reward);

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdGratifiedEvent(screenName, reward);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdGratifiedEvent(screenName, reward);
			break;
		}
	}

	public void AdAvailability(string param)
	{
		JSONObject jo = new JSONObject(param);
		Dictionary<string, string> parameters = jo.ToDictionary();

		string screenName = parameters["SCREEN_NAME"];

		bool isRewarded;
		bool.TryParse(parameters["IS_REWARDED"], out isRewarded);

		int adFormat;
		int.TryParse(parameters["AD_FORMAT"], out adFormat);

		bool isAvailable;
		bool.TryParse(parameters["IS_AVAILABLE"], out isAvailable);

		switch (adFormat)
		{
		case (int)AdFormat.Video:
			PokktAds.VideoAd.InvokeAdAvailabilityEvent(screenName, isRewarded, isAvailable);
			break;

		case (int)AdFormat.Interstitial:
			PokktAds.Interstitial.InvokeAdAvailabilityEvent(screenName, isRewarded, isAvailable);
			break;
		}
	}


	/**
	 * Banner Delegates
	 **/
	public void BannerLoaded(string param)
	{
		PokktAds.Banner.InvokeBannerLoadedEvent(param);
	}

	public void BannerLoadFailed(string param)
	{
		JSONObject jo = new JSONObject(param);
		string screenName = jo.HasField("screenName") ? jo.GetField("screenName").ToString() : "";
		string errorMessage = jo.HasField("errorMessage") ? jo.GetField("errorMessage").ToString() : "";
		PokktAds.Banner.InvokeBannerLoadFailedEvent(screenName, errorMessage);
	}


	/**
	 * IGA Delegates
	 **/

	public void IGAAssetsReady(string param)
	{
		Debug.Log("IGA assets are ready!");

		JSONObject jo = new JSONObject(param);
		if (jo.type == JSONObject.Type.ARRAY)
		{
			try
			{
				Dictionary<string, IGAAssetInfo> igaAssets = new Dictionary<string, IGAAssetInfo>();
				foreach (JSONObject entry in jo.list)
				{
					Dictionary<string, string> entryDict = entry.ToDictionary();
					
					IGAAssetInfo info = new IGAAssetInfo();

					info.OfferId = entryDict["offerId"];
					info.Path = entryDict["path"];

					int temp = 0;

					int.TryParse(entryDict["width"], out temp);
					info.Width = temp;

					int.TryParse(entryDict["height"], out temp);
					info.Height = temp;

					igaAssets.Add(info.Width + "x" + info.Height, info);
				}

				IGAHelper.IGAAssets = igaAssets;

				Debug.Log("total IGA assets: " + IGAHelper.IGAAssets.Count);

				// collect and populate all available IGA Containers
				PokktIGAContainer[] containers = FindObjectsOfType<PokktIGAContainer>();
				for (int i = 0; i < containers.Length; i++)
				{
					PokktIGAContainer container = containers[i];
					if (container == null)
						continue;
					
					container.AssignAsset();
				}

				return;
			}
			catch (Exception e)
			{
				Debug.Log("failed to parse IGA Assets info, " + e);
			}
		}

		PokktAds.InGameAd.InvokeIGAAssetsFailedEvent("could not retreive IGA Assets info");
	}

	public void IGAAssetsFailed(string param)
	{
		PokktAds.InGameAd.InvokeIGAAssetsFailedEvent(param);
	}
}
