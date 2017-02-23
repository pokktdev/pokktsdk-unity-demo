using System;

namespace Pokkt
{
	static class PokktOperations
	{
		// Standrad
		public const string SetDebug = "setDebug";
		public const string ExportLog = "exportLog";
		public const string ExportLogToCloud = "exportLogToCloud";
		public const string ShowToast = "showToast";
		public const string ShowLog = "showLog";
		public const string InitPokkt = "initPokkt";
		public const string UpdatePokktConfig = "updatePokktConfig";

		// Session
		public const string StartSession = "startSession";
		public const string EndSession = "endSession";
		public const string NotifyAppInstall = "notifyAppInstall";
		public const string TrackIAP = "trackIAP";
		
		// Offerwall Methods
		public const string GetCoins = "getCoins";
		public const string GetPendingCoins = "getPendingCoins";
		public const string CheckOfferWallCampaign = "checkOfferWallCampaign";
		
		// Video Methods
		public const string CacheAd = "cacheAd";
		public const string ShowAd = "showAd";
		public const string CheckAdAvailability = "checkAdAvailability";

		//Banner Methods
		public const string LoadBanner = "loadBanner";
		public const string LoadBannerWithRect = "loadBannerWithRect";
		public const string RemoveBanner = "removeBanner";
		public const string BannerAutoRefresh = "bannerAutoRefresh";

		// IGA Methods
		public const string FetchIGAAssets = "fetchIGAAssets";
	}
}