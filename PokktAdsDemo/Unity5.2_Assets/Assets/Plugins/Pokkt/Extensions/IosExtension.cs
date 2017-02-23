using System;
using System.Runtime.InteropServices;

namespace Pokkt.Extensions
{
	public class IosExtension : INativeExtension
	{
#if UNITY_IOS
		// internal calls
		[DllImport("__Internal")]
		private static extern void notifyNative(string operation, string param);

		[DllImport("__Internal")]
		private static extern string getSDKVersionOnNative();
#endif

		public void NotifyNative(string operation, string param)
		{
#if UNITY_IOS
			notifyNative(operation, param);
#else
			throw new InvalidOperationException("Method not implemented!");
#endif
		}

		public string GetSdkVersion()
		{
#if UNITY_IOS
			return getSDKVersionOnNative();
#else
			throw new InvalidOperationException("Method not implemented!");
#endif
		}
	}
}