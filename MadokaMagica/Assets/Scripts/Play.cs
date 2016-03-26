using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Camera.main.GetComponent<AudioSource> ().Stop ();
		this.GetComponent<AudioSource> ().Play ();
		if (this.tag == "Jugar"){
			Invoke ("cargarJuego", 1);
		} else if (this.tag == "Inicio"){
			Invoke ("cargarInicio", 1);
		}

	}

	void cargarJuego(){
		SceneManager.LoadScene ("GameScene");
	}

	void cargarInicio(){
		SceneManager.LoadScene ("MainScene");
	}


}
