using System;
using UnityEngine;

namespace Pokkt.Extensions
{
	class AndroidExtension : INativeExtension
	{
#if UNITY_ANDROID
		private const string PokktJavaClassName = "com.pokkt.plugin.PokktNativeExtension";
		private const string NativeNotifierMethodName = "notifyNative";
		private const string GetSdkVersionMethodName = "getSDKVersionOnNative";

		private static readonly AndroidJavaClass _jc = new AndroidJavaClass(PokktJavaClassName);

		private static void NotifyAndroid(string operation, string param)
		{
			_jc.CallStatic(NativeNotifierMethodName, operation, param);
		}

		private static string GetSdkVersionOnNative()
		{
			return _jc.CallStatic<string>(GetSdkVersionMethodName);
		}
#endif
		
		public void NotifyNative(string operation, string param)
		{
#if UNITY_ANDROID
			NotifyAndroid(operation, param);
#else
			throw new InvalidOperationException("Method not implemented!");
#endif
		}

		public string GetSdkVersion()
		{
#if UNITY_ANDROID
			return GetSdkVersionOnNative();
#else
			throw new InvalidOperationException("Method not implemented!");
#endif
		}
	}
}