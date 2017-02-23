using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Pokkt.IGA
{
	public class IGAHelper
	{
		class IGAData
		{
			public IGAAssetInfo assetInfo;
			public int Placed = 0;
			public int Seen = 0;
			public int Collected = 0;
		}

		public static Dictionary<string, IGAAssetInfo> IGAAssets { get; set; }
		private static Dictionary<string, IGAData> _igaDataList = new Dictionary<string, IGAData>();

		public static void AddToPlaced(IGAAssetInfo assetInfo, int count)
		{
			string size = assetInfo.Width + "x" + assetInfo.Height;
			if (!_igaDataList.ContainsKey(size))
				_igaDataList.Add(size, new IGAData());

			_igaDataList [size].assetInfo = assetInfo;
			_igaDataList [size].Placed += count;

			SyncData ();
		}

		public static void AddToSeen(IGAAssetInfo assetInfo, int count)
		{
			string size = assetInfo.Width + "x" + assetInfo.Height;
			if (!_igaDataList.ContainsKey(size))
				_igaDataList.Add(size, new IGAData());

			_igaDataList [size].assetInfo = assetInfo;
			_igaDataList [size].Seen += count;

			SyncData ();
		}

		public static void AddToCollected(IGAAssetInfo assetInfo, int count)
		{
			string size = assetInfo.Width + "x" + assetInfo.Height;
			if (!_igaDataList.ContainsKey(size))
				_igaDataList.Add(size, new IGAData());

			_igaDataList [size].assetInfo = assetInfo;
			_igaDataList [size].Collected += count;

			SyncData ();
		}

		public static void SyncData()
		{
			JSONObject jo = new JSONObject (JSONObject.Type.ARRAY);

			foreach (var entry in _igaDataList)
			{
				JSONObject igaData = new JSONObject ();
				igaData.AddField ("offerId", entry.Value.assetInfo.OfferId);
				igaData.AddField ("width", entry.Value.assetInfo.Width);
				igaData.AddField ("height", entry.Value.assetInfo.Height);
				igaData.AddField ("placed", entry.Value.Placed);
				igaData.AddField ("seen", entry.Value.Seen);
				igaData.AddField ("collected", entry.Value.Collected);
				igaData.AddField ("error", entry.Value.assetInfo.ErrorInfo);
				jo.Add (igaData);

				//jo.AddField ("size", entry.Key);
				//jo.AddField ("data", igaData);
			}

			// TODO: put a timer for syncing
			PokktAds.Analytics.UpdateIGAData(jo.ToString ());
		}
	}
}

