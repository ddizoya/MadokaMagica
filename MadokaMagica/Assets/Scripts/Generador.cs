using UnityEngine;
using System.Collections;


public class Generador : MonoBehaviour {

	public GameObject [] plataformas;
    public float tMin;
    public float tMax;
	private bool continuar = true;

	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "corriendo"); 
		NotificationCenter.DefaultCenter ().AddObserver (this, "muerte");
    }

	void muerte(Notification n){
		continuar = false;
	}

    void corriendo (Notification nt)  {
        this.Generator();
    }
	
    void Generator() {
		if (continuar) {
			Instantiate (plataformas [Random.Range (0, plataformas.Length)], transform.position, Quaternion.identity);
			Invoke ("Generator", Random.Range (tMin, tMax));
		} 
    }
}
