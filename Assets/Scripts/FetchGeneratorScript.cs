using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchGeneratorScript : MonoBehaviour {
	GameObject fetcher;
	// Use this for initialization
	void Start () {
		fetcher = Resources.Load<GameObject> ("Prefab/Fetcher");
	}
	
	// Update is called once per frame
	void Update () {
		int fetcherCount = countFetcher ();
		int materialCount = countMaterial ();
		if (materialCount > 0 && fetcherCount < 1) {
			GameObject fetch = Instantiate (fetcher);
			fetch.transform.position = transform.position;
		}
	}

	int countFetcher(){
		return GameObject.FindGameObjectsWithTag ("Fetcher").Length;
	}

	int countMaterial(){
		return GameObject.FindGameObjectsWithTag ("Material").Length;
	}

}
