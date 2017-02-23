using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Pokkt;
using Pokkt.IGA;


public enum PokktIGAType { Hoarding, Banner, Collectible, Boost }

[Serializable]
public class PokktIGAProperties : object
{
	public PokktIGAType AdType;
}

public class PokktIGAContainer : MonoBehaviour
{
	public PokktIGAProperties IGAObject;
	public Camera PlayerCamera;

	private bool _isPlaced = false;
	private bool _isSeen = false;
	private bool _isCollected = false;

	private IGAAssetInfo _assetInfo = new IGAAssetInfo();

	void Start()
	{
	}
	
	void Update()
	{
		// TODO: check with any other active camera
		PlayerCamera = PlayerCamera ?? Camera.main;
		if (_isPlaced && !_isSeen && PlayerCamera.isActiveAndEnabled)
		{
			Vector3 screenPoint = PlayerCamera.WorldToViewportPoint(transform.position);
			_isSeen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;			
			if (_isSeen)
			{
				Debug.Log ("object is seen, object: " + name);
				IGAHelper.AddToSeen (_assetInfo, 1);
			}
		}
	}

	public void NotifyCollected()
	{
		if (!_isPlaced)
			return;

		if (_isCollected)
			return;
		
		Debug.Log ("object is collected, object: " + name);
		_isCollected = true;
		IGAHelper.AddToCollected (_assetInfo, 1);
	}

	public void AssignAsset()
	{
		_isPlaced = false;
		
		string assetKey = "";
		switch (IGAObject.AdType)
		{
		case PokktIGAType.Hoarding:
			assetKey = "256x256";
			break;

		case PokktIGAType.Banner:
			assetKey = "128x128";
			break;

		case PokktIGAType.Collectible:
		case PokktIGAType.Boost:
		default:
			Debug.Log("failed to get IGA for container of type: " + IGAObject.AdType + ", using default!");
			assetKey = "32x32";
			break;
		}

		if (String.IsNullOrEmpty(assetKey))
		{
			Debug.Log("asset key marker is invalid: " + assetKey);
			return;
		}

		if (IGAHelper.IGAAssets == null || IGAHelper.IGAAssets.Count < 1)
		{
			Debug.Log("IGA Assets not available!");
			return;
		}

		if (!IGAHelper.IGAAssets.ContainsKey(assetKey))
		{
			Debug.Log("asset not available for: " + assetKey);
			return;
		}

		_assetInfo = IGAHelper.IGAAssets [assetKey];
		Debug.Log("filling container for: " + assetKey + ", image path: " + _assetInfo.Path);

		if (String.IsNullOrEmpty(_assetInfo.Path))
		{
			Debug.Log("asset path is invalid: " + assetKey);
			return;
		}

		StartCoroutine(LoadImageInContainer());
	}

	public IEnumerator LoadImageInContainer()
	{
		string prefix = Application.platform == RuntimePlatform.Android ? "file://" : "file://";
		string filePath = prefix + _assetInfo.Path.Replace(@"\/", "/");
	
		WWW w = new WWW(filePath);
		if (w.error != null && w.error.Length > 0)
		{
			Debug.Log("www error: " + w.error);
			_assetInfo.ErrorInfo = w.error;
			yield break;
		}

		yield return w;
		Texture2D texture = w.texture;
		Debug.Log(
			"texture is: " + w.texture + " (" + w.texture.dimension + ") " +
			",\n texture dimensions: " + w.texture.width + "x" + w.texture.height +
			",\n size in bytes: " + w.bytes.Length);
		GetComponent<Renderer>().material.mainTexture = texture;

		_isPlaced = true;

		// as this is new, mark it not seen and not yet collected(if needed)
		_isSeen = false;
		_isCollected = false;
		_assetInfo.ErrorInfo = "";

		// update count
		IGAHelper.AddToPlaced(_assetInfo, 1);
	}

	private static PokktIGAContainer AddIGAContainer(GameObject go)
	{
		if (go == null)
			return null;

		if (go.GetComponent<PokktIGAContainer>() != null)
		{
			Debug.Log("IGA Container already added to gameObject: " + go.name);
			return go.GetComponent<PokktIGAContainer>();
		}

		PokktIGAContainer container = go.AddComponent<PokktIGAContainer>();
		if (container.IGAObject == null)
			container.IGAObject = new PokktIGAProperties();

		// add a default Pokkt Logo to it
		//Material mat = new Material(Shader.Find("Diffuse"));
		//mat.SetTexture("_MainTex",Resources.Load("logo") as  Texture);
		//go.GetComponent<Renderer>().sharedMaterial = Resources.Load<Material>("logo");

		// this will try to assign an available asset to this container
		container.AssignAsset();

		return container;
	}

	public static PokktIGAContainer AddIGAHoarding(GameObject go)
	{
		if (go == null)
			return null;

		PokktIGAContainer container = AddIGAContainer(go);
		container.IGAObject.AdType = PokktIGAType.Hoarding;

		return container;
	}

	public static PokktIGAContainer AddIGABanner(GameObject go)
	{
		if (go == null)
			return null;

		PokktIGAContainer container = AddIGAContainer(go);
		container.IGAObject.AdType = PokktIGAType.Banner;

		return container;
	}

	public static PokktIGAContainer AddIGACollectible(GameObject go)
	{
		if (go == null)
			return null;
		
		PokktIGAContainer container = AddIGAContainer(go);
		container.IGAObject.AdType = PokktIGAType.Collectible;

		return container;
	}
	
	public static PokktIGAContainer AddIGABoost(GameObject go)
	{
		if (go == null)
			return null;
		
		PokktIGAContainer container = AddIGAContainer(go);
		container.IGAObject.AdType = PokktIGAType.Boost;

		return container;
	}
}
