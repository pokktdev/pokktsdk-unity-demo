using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Pokkt;

public class PokktDemoSelector : MonoBehaviour
{
	void Start()
	{
		PokktAds.Debugging.ShouldDebug(true);

		// video demo credentials
		string appId = "a2717a45b835b5e9f50284a38d62a74e";
		string securityKey = "iJ02lJss0M";

		// chikke sample app
		//appId = "cc41e865391d6ea371b18aff27cc10e6";
		//securityKey = "4a069e89fe4a4e4f58a26f8bff2974ba";

		// dev_xtreme_android
		appId = "4c2b7f051a130a3f530cd948d9436e45";
		securityKey = "92cc1ed3930cbe0ba69779bc547bac44";

		PokktAds.SetPokktConfig(appId, securityKey);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		//UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.
	}
	
	public void OnSelectDemoSimple()
	{
		Debug.Log("starting Pokkt Simple Demo");
		SceneManager.LoadScene ("PokktSimpleDemo");
	}
	
	public void OnSelectDemoCity()
	{
		Debug.Log("starting Pokkt City Demo (IGA)");
		SceneManager.LoadScene ("PokktCityDemo");
	}
}
