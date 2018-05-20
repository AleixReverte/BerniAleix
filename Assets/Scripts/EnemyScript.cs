using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public const float STEP = 0.09f;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float dx = player.transform.position.x - this.transform.position.x;
		float dy = player.transform.position.y - this.transform.position.y;

		float norma = Mathf.Sqrt (Mathf.Pow (dx, 2) + Mathf.Pow (dy, 2));

		dy *= STEP / norma;
		dx *= STEP / norma;

		this.transform.Translate (dx, dy, 0.0f, Space.Self);
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Ally")) {
			Destroy (coll.gameObject);
		}
		if (!coll.gameObject.tag.Equals ("Player") && !coll.gameObject.tag.Equals ("Enemy") && !coll.gameObject.tag.Equals ("Material")) {
			Destroy (this.gameObject);
			GameObject.Find("Player").GetComponent<PlayerXp> ().moreXp();
		}
	}
}
