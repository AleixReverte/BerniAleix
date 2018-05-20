using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHealth : MonoBehaviour {
	public float health;
	public float startingHealth;
	public Image healthBar;

	// Use this for initialization
	void Start () {
		startingHealth = 5;
		if (this.gameObject.tag.Equals ("Barricade"))
			startingHealth += startingHealth;
		health = startingHealth;
		healthBar.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Destroy (this.gameObject);
		healthBar.fillAmount = health / startingHealth;
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals("Enemy")) {
			health--;
		}
	}
}