using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Si es el personaje, se rompe la ejecución del programa. Si es una baldosa, la elimina. 
    //Es aquí donde irá el GameOver.
	void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "muerte");
			GameObject madoka = GameObject.Find ("Madoka");
			Destroy (madoka);
        } else {
            Destroy(other.gameObject);
        }
		
	}
}
