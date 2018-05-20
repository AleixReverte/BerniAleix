using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour{
	public const float AUMENTO_VELOCIDAD = 0.01f;
	public int turretCost;

	public GameObject prefabTurret;
	private float dirx,diry;
	private float step;
	private int dinero;
	private int materiales;

	// Use this for initialization
	void Start () {
		dirx = 0;
		diry = 0;
		step = 0.1F;
		dinero = 0;
		materiales = 0;
		turretCost = 2;
		prefabTurret = Resources.Load("Prefab/Turret") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//move (1.0F, -1.0F);
		if (Input.GetKey (KeyCode.W)) {
			setDir (0, 1);
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			unsetDir ();
		}
		if (Input.GetKey (KeyCode.A)) {
			setDir (-1, 0);
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			unsetDir ();
		}
		if (Input.GetKey (KeyCode.S)) {
			setDir (0, -1);
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			unsetDir ();
		}
		if (Input.GetKey (KeyCode.D)) {
			setDir (1, 0);
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			unsetDir ();
		}

		/**if (Input.GetKeyDown (KeyCode.Space)) {
			acelerar (0.6F);
		}
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			acelerar (-0.6F);
		}
		*/
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (this.GetComponent<PlayerBag> ().spendMaterial(turretCost)) {
				GameObject turr = Instantiate (prefabTurret);
				turr.transform.position = transform.position;
				turr.transform.Translate (new Vector3(dirx,diry,0.0F), Space.World);

			} else {
				//TODO mostrar error de no suficientes materiales
			}
		}

		move (this.transform.position.x + dirx, this.transform.position.y + diry);
	}

	public void setDir(float x, float y){
		dirx = x;
		diry = y;
	}

	public void unsetDir(){
		dirx = 0;
		diry = 0;
	}

	public bool gastarDinero (int dineroGastado) {
		if (dinero >= dineroGastado) {
			dinero -= dineroGastado;
			return true;
		}
		return false;
	}

	public void recibirDinero (int dineroRecibir) {
		dinero += dineroRecibir;
	}

	public void obtenerMaterial (int cantidad) {
		materiales += cantidad;
	}

	public void acelerar (float nivel) {
		step += (nivel * AUMENTO_VELOCIDAD);
		if (step < 0) {
			step = 0;
		}
	}

	public void move (float a,float b){
		float dx = a - this.transform.position.x;
		float dy = b - this.transform.position.y;

		float norma = Mathf.Sqrt (Mathf.Pow (dx, 2) + Mathf.Pow (dy, 2));

		dx *= step/norma;
		dy *= step/norma;
		Vector3 vec3 = new Vector3(dx,dy,0.0F);
		this.transform.Translate (vec3, Space.World);

		if (vec3 != Vector3.zero) {
			float angle = Mathf.Atan2 (vec3.y, vec3.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}

	}

	public float getX (){
		return transform.position.x;
	}

	public float getY (){
		return transform.position.y;
	}
}
