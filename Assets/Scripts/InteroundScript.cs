using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteroundScript : MonoBehaviour {

	private bool activateInterRound;
	private float interoundTime;
	private float timeElapsed;
	private float time;

	private Text counter;
	// Use this for initialization
	void Start () {
		activateInterRound = false;
		interoundTime = 0;
		timeElapsed = 0;
		time = 0;
		counter = GameObject.FindGameObjectWithTag ("RoundTimer").GetComponent<Text> ();
		counter.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (activateInterRound) {
			if (timeElapsed >= interoundTime) {
				counter.text = "";
				activateInterRound = false;
			} else {
				if (Time.realtimeSinceStartup - time > 1) {
					timeElapsed++;
					counter.text = "Next round in " + (30-timeElapsed).ToString() + " seconds";
					time = Time.realtimeSinceStartup;
				}
			}
		}
	}

	public bool isInteround(){
		return this.activateInterRound;
	}

	public void activateInteround(){
		activateInterRound = true;
		timeElapsed = 0;
		interoundTime = 30;
		counter.text = "Next round in 30 seconds";
		this.time = Time.realtimeSinceStartup;
	}
}
