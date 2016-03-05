using UnityEngine;
using System.Collections;

public class Punto : MonoBehaviour {

    //Para evitar que el personaje aumente un punto siempre que esté posado en un mismo bloque.
	private bool colision = false;
    public int puntos_a_incrementar = 1;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D col){
        if (!colision && col.gameObject.tag == "Player") {
            colision = true;
            NotificationCenter.DefaultCenter().PostNotification(this, "incrementarPuntos", puntos_a_incrementar);
        }
        
    }
}
