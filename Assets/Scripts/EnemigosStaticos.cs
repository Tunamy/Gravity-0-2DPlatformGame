using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemigosStaticos : MonoBehaviour
{

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Jugador>().QuitarVidas(collision.GetContact(0).normal);
            Debug.Log("colisiona");
            
        }
    }
}
