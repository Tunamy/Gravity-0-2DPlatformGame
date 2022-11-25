using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour
{
    public GameObject transicionG;
    public Animator transicion;
    public GameObject menuPausa;

     void Start()
    {
        transicionG.SetActive(true);
    }
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
        Time.timeScale = 1;
        transicion.Play("transicion nivel");
        Invoke("PulsarRestart", 1.1f);
        
    }

    public void salir()
    {
        Application.Quit();
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        transicion.Play("transicion nivel");
        Invoke("PulsarMainMenu", 1.1f);
    }

    public void Jugar()
    {
        transicion.Play("transicion nivel");
        Invoke("PulsarPlayGame", 1.1f);
    }

    public void Tutorial()
    {

        transicion.Play("transicion nivel");
        Invoke("PulsarTutorial", 1.1f);
    }

  
    public void PulsarPlayGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void PulsarTutorial()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void PulsarMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PulsarRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }


}

