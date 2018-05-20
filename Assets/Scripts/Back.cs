using UnityEngine.SceneManagement;
using UnityEngine;

public class Back : MonoBehaviour {

	void Start () {
		GameObject.Find ("h_lv").GetComponent<TextMesh> ().text = "Lv: " + GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().loadHealth () + "/5";
		GameObject.Find ("c_lv").GetComponent<TextMesh> ().text = "Lv: " + GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().loadCapacity () + "/5";
		GameObject.Find ("s_lv").GetComponent<TextMesh> ().text = "Lv: " + GameObject.FindGameObjectWithTag ("Data").GetComponent<Splash> ().loadSpeed () + "/5";
	}

	void OnMouseDown () {
		SceneManager.LoadScene ("Menu");
	}
}