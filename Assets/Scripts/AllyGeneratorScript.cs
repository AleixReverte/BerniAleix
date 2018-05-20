using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyGeneratorScript : MonoBehaviour {
	public int maxAlly;
	private GameObject ally;
	private float timer;
	public float time;
	// Use this for initialization
	void Start () {
		ally = Resources.Load<GameObject> ("Prefab/Ally");
		timer = 0;
		time = 10;
		maxAlly = 10;
	}
	
	// Update is called once per frame
	void Update () {
		int currAlly = GameObject.FindGameObjectsWithTag ("Ally").Length;

		if (currAlly<maxAlly && Time.realtimeSinceStartup - timer > time) {
			GameObject all = Instantiate (ally);
			all.transform.position = transform.position;
			timer = Time.realtimeSinceStartup;
		}
		
	}

	public void setMaxAlly(int ally){
		maxAlly = ally;
	}

	public void setTime(float time){
		this.time = time;
	}
		
}
