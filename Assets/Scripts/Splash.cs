using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Splash : MonoBehaviour {
	public string path;
	public string[] dataFile;


	/*File data API
	 *
	 *XP
	 *level
	 *Skillpoints
	 *Health
	 *Capacity
	 *Speed
	 *AlliesSpeed
	 *SpawnSpeed
	 *Fetchers speed
	 *Bulding HP
	 *Bullet Speed
	 *Firing Rate
	*/
	void Start () {
		path = Application.persistentDataPath + "/config.txt";
		if(!File.Exists(path)) {
			File.WriteAllLines(path, new string[]{
				"0",
				"1",
				"0",
				"1",
				"1",
				"1",
				"1",
				"1",
				"1",
				"1",
				"1",
				"1"
			});
		}

		dataFile = File.ReadAllLines (path);
		DontDestroyOnLoad (gameObject);
		StartCoroutine (init());
	}

	void OnApplicationQuit () {
		File.WriteAllLines (path, dataFile);
	}

	public int loadXp () {
		return int.Parse (dataFile [0]);
	}

	public int loadLevel () {
		return int.Parse (dataFile [1]);
	}

	public int loadSkillPoints () {
		return int.Parse (dataFile [2]);
	}

	public int loadHealth () {
		return int.Parse (dataFile [3]);
	}

	public int loadCapacity () {
		return int.Parse (dataFile [4]);
	}

	public int loadSpeed () {
		return int.Parse (dataFile [5]);
	}

	public int loadAlliesSpeed () {
		return int.Parse (dataFile [6]);
	}

	public int loadSpawnSpeed () {
		return int.Parse (dataFile [7]);
	}

	public int loadFetcherSpeed () {
		return int.Parse (dataFile [8]);
	}

	public int loadBuildingHP () {
		return int.Parse (dataFile [9]);
	}

	public int loadBulletSpeed () {
		return int.Parse (dataFile [10]);
	}

	public int loadFiringRate () {
		return int.Parse (dataFile [11]);
	}

	public void setXp (int xp) {
		dataFile [0] = xp.ToString();
	}

	public void setLevel (int level) {
		dataFile [1] = level.ToString();
	}

	public void setSkillPoints (int sp) {
		dataFile [2] = sp.ToString();
	}

	public void setHealth (int hp) {
		dataFile [3] = hp.ToString();
	}

	public void setCapacity (int bag) {
		dataFile [4] = bag.ToString();
	}

	public void setSpeed (int speed) {
		dataFile [5] = speed.ToString();
	}

	public void setAlliesSpeed (int aspeed) {
		dataFile [6] = aspeed.ToString();
	}

	public void setSpawnSpeed (int sspeed) {
		dataFile [7] = sspeed.ToString();
	}

	public void setFetcherSpeed (int fspeed) {
		dataFile [8] = fspeed.ToString ();
	}

	public void setBuildingHP (int bhp) {
		dataFile [9] = bhp.ToString ();
	}

	public void setBulletSpeed (int bspeed) {
		dataFile [10] = bspeed.ToString ();
	}

	public void setFiringRate (int fr) {
		dataFile [11] = fr.ToString ();
	}

	IEnumerator init () {
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("Menu");
	}
}
