﻿using UnityEngine;
using System.Collections;

public class ValoresCamaraGameOver : MonoBehaviour {
	public TextMesh reccord;
	public TextMesh puntuacionGameOver;
	private TextMesh marcadorPuntuacion;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		Camera.main.GetComponent<AudioSource> ().Stop ();
		marcadorPuntuacion = GameObject.Find ("Main Camera").GetComponent<Puntuacion> ().marcador;
		puntuacionGameOver.text = marcadorPuntuacion.text;
		reccord.text = GameState.state.puntuacionMaxima.ToString();
		Destroy (marcadorPuntuacion);

	}
}
