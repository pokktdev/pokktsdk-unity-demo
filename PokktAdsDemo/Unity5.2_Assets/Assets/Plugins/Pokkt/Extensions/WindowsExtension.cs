namespace Pokkt.Extensions
{
    public class WindowsExtension : INativeExtension
	{
        public WindowsExtension()
        {
#if UNITY_WSA
            PWPUnity.PokktNativeExtension.PokktDispatcher = PokktManager.DispatcherGO();
#endif
        }

        public void NotifyNative(string operation, string param)
		{
#if UNITY_WSA
            PWPUnity.PokktNativeExtension.NotifyNative(operation, param);
#else
			throw new System.InvalidOperationException("Method not implemented!");
#endif
        }

		public string GetSdkVersion()
		{
#if UNITY_WSA
            return PWPUnity.PokktNativeExtension.GetSDKVersionOnNative();
#else
			throw new System.InvalidOperationException("Method not implemented!");
#endif
        }
	}
}