using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciador : MonoBehaviour
{
    private Jogador jogadorScript;
    public GameObject[] inimigos;

	void Start ()
    {
        jogadorScript = GameObject.Find("Player").GetComponent<Jogador>();
	}
	
	void Update ()
    {
		if (jogadorScript.pontuacao == 1)
        {
            inimigos[0].SetActive(true);
        }
        else if (jogadorScript.pontuacao == 5)
        {
            inimigos[1].SetActive(true);
        }
        else if (jogadorScript.pontuacao == 10)
        {
            inimigos[2].SetActive(true);
        }
        else if (jogadorScript.pontuacao == 15)
        {
            inimigos[3].SetActive(true);
        }

        if (GameObject.Find("Player") == null)
        {
            FimdeJogo();
        }
    }

    public void FimdeJogo()
    {
        StartCoroutine(GameEnds());
    }

    IEnumerator GameEnds()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
