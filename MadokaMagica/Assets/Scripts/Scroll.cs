using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocidad;
	private bool movimiento = false;
	private float tiempoInicial = 0f;
	public bool moverScroll;

	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "corriendo");
		NotificationCenter.DefaultCenter ().AddObserver (this, "muerte");
		if (moverScroll){ 
			movimiento = true;
		}
	}

	void corriendo(Notification n){
		this.movimiento = true;
		this.tiempoInicial = Time.time;

	}

	void muerte(Notification n){
		movimiento = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (movimiento){
			gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (((Time.time - tiempoInicial)* velocidad) % 1, 0);
		}

	}
}
