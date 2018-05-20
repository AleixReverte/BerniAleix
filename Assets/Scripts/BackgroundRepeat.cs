using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundRepeat : MonoBehaviour {
	//Esenario de 100*100, y va de +50 a -50
	public float adicionDeEnemigosPorRonda;
	public int enemigos;
	public int ronda;
	public float velocidadDeAparicion;
	public float tiempo;
	private GameObject enemigo;
	private GameObject material;
	private GameObject player;

	private Text roundCounter;

	private float tiempoMaterial;
	private float maxMaterial = 40;
	private float maxTiempoActual;
	// Use this for initialization
	void Start () {
		adicionDeEnemigosPorRonda = 2;
		ronda = 1;
		velocidadDeAparicion = 1;
		enemigo = Resources.Load<GameObject>("Prefab/Enemy");
		material = Resources.Load<GameObject> ("Prefab/Material");
		tiempo = Time.realtimeSinceStartup;
		enemigos = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
		roundCounter = GameObject.FindGameObjectWithTag ("RoundCounter").GetComponent<Text> ();
		roundCounter.text = ronda.ToString();
		tiempoMaterial = 0;
		maxTiempoActual = 1F;
	}
	
	// Update is called once per frame
	void Update () {
		MaterialSpawning ();
		enemySpawning ();
	}

	void MaterialSpawning(){
		if (Time.realtimeSinceStartup - tiempoMaterial > maxTiempoActual) {
			int cuantos = Mathf.RoundToInt(Random.Range (1, maxMaterial));
			Debug.Log ("Test");
			if (GameObject.FindGameObjectsWithTag ("Material").Length < maxMaterial) {
				Debug.Log ("Test2");
				for (int i = 0; i < cuantos; i++) {
					Vector3 position = 40 * Random.insideUnitCircle;
					GameObject mat = Instantiate (material);
					mat.transform.position = position;
				}
				tiempoMaterial = Time.realtimeSinceStartup;
			}
		}
	}
	void enemySpawning(){
		if (GetComponent<InteroundScript> ().isInteround()) {
			return;
		}
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0 && enemigos >= adicionDeEnemigosPorRonda * ronda) {
			//Ronda finalizada
			ronda++;
			roundCounter.text = ronda.ToString();
			GetComponent<InteroundScript> ().activateInteround ();
			enemigos = 0;
		} else if(enemigos<adicionDeEnemigosPorRonda*ronda){
			if (Time.realtimeSinceStartup - tiempo > velocidadDeAparicion) {
				int nEne = Mathf.RoundToInt(Random.Range (1, adicionDeEnemigosPorRonda));
				for (; nEne > 0; nEne--) {
					Vector3 position = obtainPosition();
					GameObject enemy = Instantiate (enemigo);
					enemy.transform.position = position;
					enemigos++;
				}
				tiempo = Time.realtimeSinceStartup;
			}
		}
	}
		
	public Vector3 obtainPosition(){
		Vector3 Position = 40 * Random.insideUnitCircle;
		while (Vector3.Distance (Position, player.transform.position) < 10) {
			Position = 40 * Random.insideUnitCircle;
		}
		return Position;
	}
}
