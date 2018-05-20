using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetcherScript : MonoBehaviour {

	private GameObject target;
	private bool foundTarget;
	private float step;
	private Vector3 distToTarget;
	// Use this for initialization
	void Start () {
		target = null;
		foundTarget = false;
		step = 0.01F;
		distToTarget = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			if (foundTarget) {
				if (distToTarget == Vector3.zero) {
					distToTarget = target.transform.position - transform.position;
					target.GetComponent<MaterialScript> ().setCarrier (this.gameObject);
				}
				gotoPlayer ();
			} else {
				gotoTarget ();
			}
		} else {
			target = findNearestMaterial ();
			if (target == null) {
				Destroy (this.gameObject);
			} 
		}
	}

	void gotoPlayer(){
		GameObject player = GameObject.Find ("Player");
		Vector3 direction = player.transform.position - transform.position;
		transform.Translate (step*direction.normalized,Space.World);
		target.transform.position = transform.position;
		target.transform.Translate (distToTarget, Space.Self);

	}

	void gotoTarget(){
		Vector3 direction = target.transform.position-transform.position;
		direction = direction.normalized;
		transform.Translate (step*direction, Space.World);
	}

	GameObject findNearestMaterial(){
		GameObject[] materials = GameObject.FindGameObjectsWithTag ("Material");
		GameObject closestMaterial=null;
		float distance = float.MaxValue;

		foreach(GameObject material in materials){
			float dist = Vector3.Distance (material.transform.position, transform.position);
			if (dist < distance && material.GetComponent<MaterialScript>().getCarrier() == null) {
				distance = dist;
				closestMaterial = material;
			}
		}
		return closestMaterial;
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (foundTarget) {
			if (coll.gameObject.tag.Equals ("Player")) {
				target = null;
				Destroy (this.gameObject);
			}
		} else {
			if (coll.gameObject.tag.Equals ("Material")) {
				foundTarget = true;
			}
		}
	}
		
}
