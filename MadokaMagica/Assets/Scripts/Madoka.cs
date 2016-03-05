using UnityEngine;
using System.Collections;

public class Madoka : MonoBehaviour
{

    //Atributos para ejecutar el salto.
    public float salto = 100f;
    public LayerMask masc;
    public Rigidbody2D rg;

    //Evaluadores de colisión en suelo.
    public bool isGrounded;
    public LayerMask mascarasuelo;
    private float radio = 0.05f;
    public Transform comprobador;

    //Atributos para cambios de estado en la animación.
    Animator animator;

    //Att para que empiece a correr
    bool corriendo =  false;
    public float velocidad = 10f;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    void Start() {
    }
 

    void FixedUpdate(){
        if (corriendo == true){
            rg.velocity = new Vector2(velocidad, rg.velocity.y);
        }
        isGrounded = Physics2D.OverlapCircle(comprobador.position, radio, mascarasuelo);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Velocidad", rg.velocity.x);
  
    }


    // Update is called once per frame
    void Update() {   
        if (Input.GetMouseButton(0)) {
            if (corriendo) {
                if(isGrounded)
                    rg.AddForce(new Vector2(0, salto));
            } else {
                this.corriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "corriendo");

            }
        }
    }

}


