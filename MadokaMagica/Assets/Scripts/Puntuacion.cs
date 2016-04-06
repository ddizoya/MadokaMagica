using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

    private int puntuacion = 0;
	public TextMesh marcador;

	void Start () {
	    NotificationCenter.DefaultCenter().AddObserver(this, "incrementarPuntos");
		NotificationCenter.DefaultCenter ().AddObserver (this, "muerte");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void muerte(Notification n){
		if(puntuacion > GameState.state.puntuacionMaxima){
		GameState.state.puntuacionMaxima = this.puntuacion;
		GameState.state.Guardar ();
		}
	}

    void incrementarPuntos(Notification n){
        int puntos = (int) n.data;
        puntuacion += puntos;
		marcador.text = puntuacion.ToString ();
    }


}
