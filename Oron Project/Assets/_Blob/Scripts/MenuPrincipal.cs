using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void CarregarFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void CarregarFase2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}