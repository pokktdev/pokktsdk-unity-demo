using UnityEngine;
using System.Collections;
using Pokkt;

public class PokktDemoUIBehavior : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	public void OnClickFetchIGAAssets()
	{
		PokktAds.InGameAd.FetchAssets("default");
	}

	public void OnClickCacheVideoAd()
	{
		PokktAds.VideoAd.CacheRewarded("default");
	}

	public void OnClickShowVideoAd()
	{
		PokktAds.VideoAd.ShowRewarded("default");
	}

	public void OnClickShowInterstitial()
	{
		PokktAds.Interstitial.ShowRewarded("default");
	}

	public void OnLoadBanner()
	{
		PokktAds.Banner.LoadBanner("UnityDemoBannerAndroid", (int)BannerPosition.BottomCenter);
		//PokktManager.LoadBannerWithRect("UnityDemoBannerAndroid",50,300,100,100);
		//PokktManager.BannerAutoRefresh(true);

		// TODO:
		//ScreenManagerGO.GetComponent<ScreenManager>().OpenScreen("DemoBanner");
	}

	public void GenerateCollectibles(int count)
	{
		float xPos = 0f;
		float yPos = 1.76f;
		float zPos = 22f;
		for (int i = 0; i < count; i++)
		{
			Object collectiblePrefab = Resources.Load("Collectible");
			if (collectiblePrefab == null)
			{
				Debug.Log("failed to load prefab: Collectible");
				break;
			}
			
			GameObject go = (GameObject)GameObject.Instantiate(collectiblePrefab);
			go.transform.position = new Vector3(xPos, yPos, zPos);
			zPos += 1;
			
			// make it an IGA container
			PokktIGAContainer.AddIGACollectible(go);
		}
	}
}
