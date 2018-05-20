using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerXp : MonoBehaviour {
	public Slider xpSlider;
	public Text levelText;
	public int xp, nextLevel, level, skillPoints, progress;

	// Use this for initialization
	void Start () {
		level = GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().loadLevel ();
		xp = GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().loadXp ();
		nextLevel = level * 5;
		skillPoints = GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().loadSkillPoints ();;
		xpSlider.value = progress = (xp * 100) / nextLevel;
		levelText.text = level.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moreXp () {
		xp++;
		if (xp >= nextLevel) {
			level++;
			nextLevel = level * 5;
			xp = 0;
			skillPoints++;
		}
		progress = (xp * 100) / nextLevel;
		xpSlider.value = progress;
		levelText.text = level.ToString();
	}
}
