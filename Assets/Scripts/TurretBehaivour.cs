using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaivour : MonoBehaviour {
	public const float minDist = 5.0F;
	public GameObject bullet;
	private float currTime;
	public float timeout = 0.5F;
	// Use this for initialization
	void Start () {
		currTime = 0;
		bullet = Resources.Load ("Prefab/Bullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup - currTime > timeout) {
			currTime = Time.realtimeSinceStartup;
			GameObject Enemy = findClosestEnemyToRange(GameObject.FindGameObjectsWithTag ("Enemy"));
			if (Enemy != null) {
				GameObject bul = Instantiate (bullet);
				bul.transform.position = transform.position;
				bul.transform.Translate (new Vector3 (0F, -0.561F, 0F));
				ProjectileBehaivour beh = bul.GetComponent<ProjectileBehaivour>();
				Vector3 direct = Enemy.transform.position - transform.position;
				beh.setDirection (direct.x,direct.y);
			}
		}

	}

	GameObject findClosestEnemyToRange(GameObject[] enemies){
		GameObject closestEnemy=null;
		float distance = float.MaxValue;

		foreach(GameObject enemy in enemies){
			float dist = Vector3.Distance (enemy.transform.position, transform.position);
			if (dist < distance) {
				distance = dist;
				closestEnemy = enemy;
			}
		}

		if (distance < minDist) {
			return closestEnemy;
		}
		return null;
	}
}