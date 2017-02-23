using UnityEngine;
using Pokkt.Extensions;


namespace Pokkt
{
	internal static class PokktNativeExtension
	{
		public static INativeExtension GetNativeExtension()
		{
		    if (Application.platform == RuntimePlatform.Android)
		        return new AndroidExtension();

		    if (Application.platform == RuntimePlatform.IPhonePlayer)
		        return new IosExtension();

#if UNITY_WSA
            if (Application.platform == RuntimePlatform.WSAPlayerARM || 
                Application.platform == RuntimePlatform.WSAPlayerX64 || 
                Application.platform == RuntimePlatform.WSAPlayerX86)
                return new WindowsExtension();
#endif

            Debug.LogWarning("[UNITY] Performer not implemented for platform: " + Application.platform);
		    return null;
		}

		public static void NotifyNative(string operation)
		{
			NotifyNative(operation, "");
		}

		public static void NotifyNative(string operation, string param)
		{
			Debug.Log("[UNITY] Performing operation: " + operation + " with params: " + param);
			INativeExtension performer = GetNativeExtension();
			if (performer != null)
				performer.NotifyNative(operation, param);
		}

		public static string GetSdkVersion()
		{
			Debug.Log("[UNITY] Getting Pokkt SDK version...");
			INativeExtension performer = GetNativeExtension();
			if (performer != null)
				return performer.GetSdkVersion();

			return "";
		}
	}
}