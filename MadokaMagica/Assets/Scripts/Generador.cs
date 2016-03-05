using UnityEngine;
using System.Collections;


public class Generador : MonoBehaviour {

	public GameObject [] plataformas;
    public float tMin;
    public float tMax;

	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "corriendo"); //Clase de escucha entre Madoka.cs y  ésta. Cuando el personaje empieza a mover, se empezarán a generar los niveles. 

    }
    void corriendo (Notification nt)  {
        this.Generator();
    }
	
    void Generator() {
        Instantiate(plataformas[Random.Range(0, plataformas.Length)], transform.position, Quaternion.identity);
        Invoke("Generator", Random.Range(tMin,tMax));
       
    }
}
