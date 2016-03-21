using UnityEngine;
using System.Collections;

public class Kyubey : MonoBehaviour {

	public int puntos_a_incrementar = 1;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {
			NotificationCenter.DefaultCenter().PostNotification(this, "incrementarPuntos", puntos_a_incrementar);
		}
			Destroy (gameObject);
   }

}