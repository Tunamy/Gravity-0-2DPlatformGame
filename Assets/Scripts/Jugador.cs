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

    public SpriteRenderer[] piñasSprites;
    public int piñas = 0;
    

    
    public Vector2 velocidadRebote;

    

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



        if (vulnerable)
        {
            if (jugador.velocity.x > 0.1)
                sprite.flipX = false;
            else if (jugador.velocity.x < -0.1)
                sprite.flipX = true;


            float entradaX = Input.GetAxis("Horizontal");
            jugador.velocity = new Vector2(entradaX * velocidad, jugador.velocity.y);

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && tocandoEscenario && ((jugador.velocity.y <= 0.2) && (jugador.velocity.y >= -0.2)))
                Saltar();
        }
        
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
        animator.SetBool("vulnerable", vulnerable);

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

    public void Rebote(Vector2 golpeado)
    {
        if(invertido==false)
            jugador.velocity = new Vector2(-velocidadRebote.x * golpeado.x, velocidadRebote.y);
        else
            jugador.velocity = new Vector2(-velocidadRebote.x * golpeado.x, -velocidadRebote.y);
    }

    public void QuitarVidas(Vector2 posicionEnemigo) 
    {

        if (vulnerable)
        {
            vulnerable= false;

            sprite.color = Color.white;

            animator.Play("hit");

            Rebote(posicionEnemigo);

            if (--vidas == 0)
            {
                corazones[0].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 40); // muerto
                FinJuego();
            }
            else if (vidas < 2)
            {
                corazones[1].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 40);
            }
            else if (vidas < 3)
            {
                corazones[2].gameObject.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 40);
                //Destroy(corazones[2].gameObject);
            }

            Invoke("HacerVulnerable", 0.4f);
        }
    }
    private void HacerVulnerable()
    {
        vulnerable= true;
        if(fuerzaSalto == 17.5f || fuerzaSalto == -17.5f)
        {
            sprite.color = new Color32(241, 160, 175, 255);
        }
    }

    public void CogerPiña()
    {
        if (++piñas == 3)
        {
            piñasSprites[2].color = Color.white; // Ganas
            
             
        }
        else if (piñas == 2)
        {
            piñasSprites[1].color = Color.white;
        }
        else if (piñas == 1)
        {
            piñasSprites[0].color = Color.white;
        }
    }

    public void SiguienteNivel()
    {
        //transicion.gameObject.SetActive(true);
        
        Invoke("CambioEscena", 2);
    }
    public void CambioEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //siguiente nivel
    }



    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // que carge la escena activa, la comienza desde 0 + 1 para la siguiente escena
    }
     
}

