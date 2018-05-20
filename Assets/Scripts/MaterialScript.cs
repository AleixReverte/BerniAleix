using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour {
	private GameObject carrier;
	// Use this for initialization
	void Start () {
		carrier = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setCarrier(GameObject carrier){
		this.carrier = carrier;
	}

	public GameObject getCarrier(){
		return carrier;
	}
}
