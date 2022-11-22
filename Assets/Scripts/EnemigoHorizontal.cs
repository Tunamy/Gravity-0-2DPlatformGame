using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHorizontal : MonoBehaviour
{
    private GameObject enemigo;
    public int velocidad;
    private Vector3 posicionInicio;
    public Vector3 posicionFinal;
    private bool moviendoAFin;

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponent<GameObject>();
        posicionInicio = transform.position;
        //posicionFinal = new Vector3(posicionInicio.x + 4 , posicionInicio.y, posicionInicio.z);
        moviendoAFin = true;
       

    }

    // Update is called once per frame
    void Update()
    {
        MoverEnenmigo();

    }

    private void MoverEnenmigo()
    {
        Vector3 posicionDestino = (moviendoAFin ? posicionFinal : posicionInicio); // si es true moviendoAfin es igual a posicion final si no es igual a posicion inicio
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime); //movetowards te mueve el objeto a un sitio
        if (transform.position == posicionFinal) // si llega al final se mueve otra vez.
            moviendoAFin = false;
        if (transform.position == posicionInicio)
            moviendoAFin = true;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Jugador>().QuitarVidas();
            Debug.Log("colisiona");
        }
    }
    
            
    


    

}
