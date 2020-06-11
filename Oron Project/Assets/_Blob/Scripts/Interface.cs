using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject victoryText;
    public GameObject loseText;
    public bool jogoPausado = false;
    private Jogador jogadorScript;
    private Gerenciador gScript;

    private void Start()
    {
        jogadorScript = GameObject.Find("Player").GetComponent<Jogador>();
        gScript = GameObject.Find("Gerenciador").GetComponent<Gerenciador>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if (jogadorScript.pontuacao == 50)
        {
            victoryText.SetActive(true);
            loseText.SetActive(false);
            gScript.FimdeJogo();
        }
    }

    public void PauseGame()
    {
        jogoPausado = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        jogoPausado = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
        jogoPausado = false;
        Time.timeScale = 1;
    }
}