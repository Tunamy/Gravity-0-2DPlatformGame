using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    private Animator animator;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            
            
            //collision.gameObject.GetComponent<Jugador>().SaltoBoost();
            animator.Play("triger");


        }
    }
}
