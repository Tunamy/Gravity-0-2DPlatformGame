using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float efectoParallax; //retardo respecto a la camara ponemos el numero en unity
    private Transform camara;
    private Vector3 camaraUltimaPos;


    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main.transform; //accedemos a la posicion de la camara
        camaraUltimaPos = camara.position; //se la damos a camara ultima posicion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 movimientoFondo = camara.position - camaraUltimaPos;
        transform.position += new Vector3(movimientoFondo.x * efectoParallax, movimientoFondo.y, 0);
        camaraUltimaPos = camara.position;
    }
}
