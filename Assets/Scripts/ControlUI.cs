using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour
{
     public GameObject menuPausa;
    public void MenuPausa() 
    {
        if (menuPausa.activeSelf == false)
        {
            menuPausa.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menuPausa.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Reastart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void salir()
    {
        Application.Quit();
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    
}
