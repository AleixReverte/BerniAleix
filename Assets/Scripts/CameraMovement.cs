using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private GameObject gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 location = new Vector3 (gm.transform.position.x, gm.transform.position.y, 
			                   this.transform.position.z);
		this.transform.position = location;
	}
}
