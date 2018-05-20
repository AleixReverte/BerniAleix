using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerHealth : MonoBehaviour {
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);		// The colour the damageImage is set to, to flash.
	public bool invulnerable;
	public float damageTime;

	public string file;

	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.


	void Awake ()
	{
		invulnerable = false;
		currentHealth = startingHealth;
	}


	void Update () {
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		// Reset the damaged flag.
		damaged = false;

		if (invulnerable) {
			if (Time.realtimeSinceStartup - damageTime >= 3) {
				invulnerable = false;
			}
		}
	}


	public void takeDamage (int amount)	{
		// Set the damaged flag so the screen will flash.
		damaged = true;

		// Reduce the current health by the damage amount.
		if (!invulnerable) {
			currentHealth -= amount;
			invulnerable = true;
			damageTime = Time.realtimeSinceStartup;
		}

		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;


		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals("Enemy")) {
			if (!invulnerable) {
				Destroy (coll.gameObject);
				GameObject.Find("Player").GetComponent<PlayerXp> ().moreXp();
			}
			takeDamage ((int)Mathf.Ceil (100 / 3.0f));
		}
	}

	void Death () {
		file = Application.persistentDataPath + "/config.txt";
		isDead = true;

		GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().setXp (gameObject.GetComponent<PlayerXp> ().xp);
		GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().setLevel (gameObject.GetComponent<PlayerXp> ().level);
		GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().setSkillPoints (gameObject.GetComponent<PlayerXp> ().skillPoints);

		SceneManager.LoadScene ("Menu");
	}       
}
