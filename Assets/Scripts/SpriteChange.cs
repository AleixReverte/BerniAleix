using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {
	public const  float period = 0.1F;

	public float activeTime = 0.0F;
	private Sprite[] sprites;
	public int numberOfFrames;
	private int counter;
	// Use this for initialization
	void Awake () {
		Debug.Log (this.tag);
		sprites = Resources.LoadAll<Sprite> ("SpriteSheets/" + this.tag);
		numberOfFrames = sprites.Length;
		if (this.tag.Equals ("Enemy"))
			numberOfFrames = 6;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > activeTime) {
			activeTime += period;
			counter = (counter + 1) % numberOfFrames;
			this.GetComponent<SpriteRenderer> ().sprite = sprites [counter];
		}
	}
}