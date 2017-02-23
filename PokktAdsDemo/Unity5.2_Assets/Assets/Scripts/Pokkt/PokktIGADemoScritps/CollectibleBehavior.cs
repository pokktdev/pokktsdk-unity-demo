using UnityEngine;
using System.Collections;

public class CollectibleBehavior : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		Destroy(this.gameObject);
	}
}
