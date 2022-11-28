using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gravedad : MonoBehaviour
{
    public AudioSource gravedad;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Jugador>().GravedadInvertida(); 
            Debug.Log("colisiona");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            gravedad.Play();
        }

    }

}
