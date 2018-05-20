using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllayScript : MonoBehaviour {
	private const float STEP = 0.11F;
	private GameObject[] enemies;
	private float angle;
	private GameObject player;
	// Use this for initialization
	void Start () {
		angle = 0;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		if (enemies.Length>0) {
			moveAllyToEnemy ();
		} else {
			moveAllyAroundPlayer ();
		}


	}

	void moveAllyAroundPlayer(){
		Vector3 distance = (player.transform.position - this.transform.position);
		if (distance.magnitude > 5) {
			this.transform.Translate (STEP * distance.normalized, Space.Self);
		}
		if (distance.magnitude < 3) {
			this.transform.Translate (-STEP * distance.normalized, Space.Self);
		}
		if (distance.magnitude > 20) {
			Destroy (this.gameObject);
		}
	}

	void moveAllyToEnemy ()
	{
		GameObject enemy = findNearestEnemy ();
		float dx = enemy.transform.position.x - this.transform.position.x;
		float dy = enemy.transform.position.y - this.transform.position.y;
		float norm = Mathf.Sqrt (Mathf.Pow (dx, 2) + Mathf.Pow (dy, 2));
		dx *= STEP / norm;
		dy *= STEP / norm;
		this.transform.Translate (dx, dy, 0.0F, Space.World);
	}

	GameObject findNearestEnemy(){
		GameObject gm = null;
		float nearestDistance = float.MaxValue;

		foreach (GameObject enemy in enemies) {
			var sqrMagnitude = (this.transform.position - enemy.transform.position).sqrMagnitude;
			if (sqrMagnitude < nearestDistance) {
				gm = enemy;
				nearestDistance = sqrMagnitude;
			}
		}

		return gm;
	}
}
