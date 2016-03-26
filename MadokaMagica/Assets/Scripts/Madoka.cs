using UnityEngine;
using System.Collections;

public class Madoka : MonoBehaviour {

    //Atributos para ejecutar el salto. Aplicaremos una fuerza de salto al rigidbody del personaje para hacer esto.
    public float salto = 100f;
    public LayerMask masc;
    public Rigidbody2D rg;

    //Evaluadores de colisión en suelo. Los necesitamos para comprobar que el personaje ha entrado en contacto con el colider de la plataforma, y así darle permisos de salto o no. 
    public bool isGrounded;
    public LayerMask mascarasuelo;
    private float radio = 0.05f;
    public Transform comprobador;

    //Objeto con el que le diremos, en cada momento, a qué animación debe cambiar según si está corriendo, saltando o quieto el personaje. 
    private Animator animator;

    //Att para comprobar si el personaje se está moviendo o no, y la velocidad que va a tener.
    bool corriendo =  false;
    public float velocidad = 10f;

	//Array para los sonidos de salto que tenemos asignado al personaje (son 3 diferentes).
	private AudioSource [] sonidosSalto;


	//Nada más iniciarse la ejecución del gameObject que tiene asinado este script, se cogerá su animador y los sonidos para el salto. 
	//El array de sonidosSalto tiene 3 sonidos distintos. 
    void Awake(){
        animator = GetComponent<Animator>();
		sonidosSalto = GetComponents<AudioSource> ();
    }

    void Start() {
    }
 

	//Si el personaje está en estado 'corriendo', se le asigna una velocidad a dicho personaje. En cada fotograma se evaluará si está en contacto con el suelo, y se le notificará al animador.
    void FixedUpdate(){
        if (corriendo){
            rg.velocity = new Vector2(velocidad, rg.velocity.y);
        }
        isGrounded = Physics2D.OverlapCircle(comprobador.position, radio, mascarasuelo);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Velocidad", rg.velocity.x);
  
    }


    //Evalúa el salto. Si el personaje no está corriendo, comenzará a correr con el primer clic. A partir de ahí, directamente se evalúa el salto y el grito del personaje al saltar. 
	//Cuando salta, se escuchará un sonido aleatorio entre los 3 disponibles.
    void Update() {   
        if (Input.GetMouseButtonDown(0)) {
            if (corriendo) {
				if (isGrounded) {
					sonidosSalto[Random.Range(0, sonidosSalto.Length)].Play();
					rg.AddForce (new Vector2 (0, salto));
				}   
            } else {
                this.corriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "corriendo"); //Avisamos que empezamos a correr a otra clase a la espera de que esta se mueva. 

            }
        }
    }

}


