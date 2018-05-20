using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {
	void OnMouseDown () {
		if (gameObject.GetComponent<TextMesh> ().text.Equals ("Play")) {
			SceneManager.LoadScene ("PlayScreen");
		}
		
		if (gameObject.GetComponent<TextMesh> ().text.Equals ("Skills")) {
			SceneManager.LoadScene ("SkillScreen");
		}

		if (gameObject.GetComponent<TextMesh> ().text.Equals ("Upgrades")) {
			SceneManager.LoadScene ("UpgradeScreen");
		}
	}
}
