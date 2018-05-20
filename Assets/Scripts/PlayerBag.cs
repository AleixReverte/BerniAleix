using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBag : MonoBehaviour {
	public Slider bagSlider;
	public Text bagFull;
	public int material, level, capacity;
	private bool painted;
	// Use this for initialization
	void Start () {
		material = 0;
		level = 1;
		capacity = 10;
		painted = false;
		bagFull.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Material")) {
			if (!(material >= capacity * level - 1)) {
				GameObject carrier;
				if ((carrier = coll.gameObject.GetComponent<MaterialScript> ().getCarrier ()) != null) {
					Destroy (carrier);
				}
				Destroy (coll.gameObject);
				moreBag ();
			} else {
				bagFull.color = new Color (1f, 1f, 1f, 1f);
				painted = true;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (painted)	bagFull.color = Color.clear;
	}

	void updateSlider () {
		bagSlider.value = (material * 100) / (capacity * level);
	}

	public bool spendMaterial (int coste){
		if (material >= coste) {
			material -= coste;
			updateSlider ();
			return true;
		}
		return false;
	}

	void moreBag () {
		material++;
		updateSlider ();
	}
}
