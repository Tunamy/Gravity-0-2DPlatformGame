using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    public int velocidad;
    public float fuerzaSalto;

    private Rigidbody2D jugador;
    private SpriteRenderer sprite;
    
    private Animator animator;
    bool tocandoEscenario = false;
    public bool invertido = false;

    public Camera camaraPrincipal;

    public GameObject[] corazones;
    public int vidas = 3;
    private bool vulnerable = true;

    

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // metemos las animaciones en la variable animator
    }

    
    void Update()
    {
        
        
        camaraPrincipal.transform.position = new Vector3(jugador.position.x + 6, camaraPrincipal.transform.position.y, camaraPrincipal.transform.position.z);
        
        

        if (jugador.velocity.x > 0.1)
            sprite.flipX = false;
        else if (jugador.velocity.x < -0.1)
            sprite.flipX = true;


        float entradaX = Input.GetAxis("Horizontal"); 
        jugador.velocity = new Vector2(entradaX * velocidad, jugador.velocity.y); 

        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow)) && tocandoEscenario && ((jugador.velocity.y <= 0.2) && (jugador.velocity.y >= -0.2)))
            Saltar();
        
        AnimarJugador();



       

    }

  
    void Saltar()
    {
        jugador.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        tocandoEscenario = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "escenario")
            tocandoEscenario = true;

    }

    private void AnimarJugador()
    {
        animator.SetFloat("velocidady", jugador.velocity.y);
        animator.SetFloat("velocidadx", Math.Abs(jugador.velocity.x));
        animator.SetBool("ensuelo", tocandoEscenario);

        if(invertido==true)
            animator.SetFloat("velocidady", -jugador.velocity.y);
    }

    public void GravedadInvertida()
    {
        
        transform.localScale = new Vector3(1, transform.localScale.y *-1, 1);
        jugador.gravityScale = -jugador.gravityScale;
        fuerzaSalto = -fuerzaSalto;
        invertido = !invertido;
        
    }

   
   
    public void SaltoBoost()
    {
       
            fuerzaSalto = fuerzaSalto * 1.75f;
            sprite.color = new Color32(241, 160, 175, 255);
            StartCoroutine(saltoNormal());
             
    }

    IEnumerator saltoNormal() // vuelva a la normalidad despues de f segundos
    {  
            yield return new WaitForSeconds(3f);
            fuerzaSalto = fuerzaSalto/1.75f;
            sprite.color = Color.white;

     
    }

    public void QuitarVidas() 
    {

        if (vulnerable)
        {
            vulnerable= false;

            animator.Play("hit");

            if (--vidas == 0)
            {
                Destroy(corazones[0].gameObject); // muerto
            }
            else if (vidas < 2)
            {
                Destroy(corazones[1].gameObject);
            }
            else if (vidas < 3)
            {
                Destroy(corazones[2].gameObject);
            }

            Invoke("HacerVulnerable", 1f);
        }
    }
    private void HacerVulnerable()
    {
        vulnerable= true;
    }


    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // que carge la escena activa, la comienza desde 0 + 1 para la siguiente escena
    }
     
}

