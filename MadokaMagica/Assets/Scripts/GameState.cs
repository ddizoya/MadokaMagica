using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameState : MonoBehaviour {

	public static GameState state;
	private String datos;
	public int puntuacionMaxima = 0;

   //Estado del juego estático, porque sólo necesito que exista uno para todo el juego. Se aplica a un gameObject en casa escena. 
	//Si ya hay una instancia no nula de un estado de juego, se destruye la nueva conservando la anterior. 
   void Awake(){
		datos = Application.persistentDataPath + "/datos.dat";
		if (state == null) {
			state = this;
			DontDestroyOnLoad (gameObject);
		} else if (state != this) {
			Destroy (gameObject);
		}
    }


	void Start () {
		Cargar ();
	}
	
	
	void Update () {
	
	}

	public void Guardar() {
		
		BinaryFormatter bin = new BinaryFormatter ();
		FileStream fs = File.Create(datos);
		MaxPuntuacion maxp = new MaxPuntuacion ();
		maxp.puntuacion = this.puntuacionMaxima;
		bin.Serialize (fs, maxp);
		fs.Close ();
	}

	void Cargar(){
		if (File.Exists (datos)) {
			BinaryFormatter bin = new BinaryFormatter ();
			FileStream fs = new FileStream (datos, FileMode.Open);
			MaxPuntuacion maxp = (MaxPuntuacion)bin.Deserialize (fs);
			this.puntuacionMaxima = maxp.puntuacion;
			fs.Close ();
		} else {
			puntuacionMaxima = 0;
		}
		
	}
}

[Serializable]
class MaxPuntuacion{
	public int puntuacion;
}