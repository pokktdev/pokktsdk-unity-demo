namespace Pokkt.Extensions
{
	public interface INativeExtension
	{
		void NotifyNative(string operation, string param);
		string GetSdkVersion();
	}
}
