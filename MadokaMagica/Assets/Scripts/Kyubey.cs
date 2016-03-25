using UnityEngine;
using System.Collections;

public class Kyubey : MonoBehaviour {

	public int puntos_a_incrementar = 1;
	public Rigidbody2D body;
	// Use this for initialization

	void Start () {
		body =  GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		Destroy (body);
		if (collider.tag == "Player") {
			NotificationCenter.DefaultCenter().PostNotification(this, "incrementarPuntos", puntos_a_incrementar);
			Destroy (gameObject);
		} else if (collider.tag == "Destructor"){
			Destroy (gameObject);
		} 
			
   }

}