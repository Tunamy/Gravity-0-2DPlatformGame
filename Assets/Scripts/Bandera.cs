using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    private Animator animator;
    public Jugador jugador;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (jugador.piñas >= 3)
            {
                collision.gameObject.GetComponent<Jugador>().SiguienteNivel();
                animator.Play("triger");
            }

        }
    }
}
