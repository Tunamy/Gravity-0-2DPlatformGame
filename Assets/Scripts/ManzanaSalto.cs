using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class ManzanaSalto : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
            collision.gameObject.GetComponent<Jugador>().SaltoBoost();
           
           
            gameObject.SetActive(false);

            Invoke("SpawnManzana", 2.5f);
            


        }
    }


    

    void SpawnManzana() 
    {
        gameObject.SetActive(true);
        

    }

}
