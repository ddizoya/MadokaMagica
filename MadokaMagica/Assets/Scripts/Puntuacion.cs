using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

    private int puntuacion = 0;
	
	void Start () {
	    NotificationCenter.DefaultCenter().AddObserver(this, "incrementarPuntos");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void incrementarPuntos(Notification n){
        int puntos = (int) n.data;
        puntuacion += puntos;
        Debug.Log("Incrementado " + puntos +". Total: " + puntuacion);
    }
}
