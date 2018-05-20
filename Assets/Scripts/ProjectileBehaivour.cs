using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaivour : MonoBehaviour {
	private const float step = 0.12F;

	public float dirx,diry;
	// Use this for initialization
	void Awake () {
		dirx = 0;
		diry = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec3 = new Vector3 (dirx, diry, 0);
		transform.Translate (step*vec3.normalized);
		if (!existsEnemies()) {
			Destroy (this.gameObject);
		}
	}

	private bool existsEnemies(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		return enemies.Length>0;
	}

	public void setDirection(float x, float y){
		dirx = x;
		diry = y;
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Enemy")) {
			Destroy (this.gameObject);
		}
	}
}