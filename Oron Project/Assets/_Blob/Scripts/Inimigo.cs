using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject projetil;
    private Transform alvo;
    public float cadencia = 1;
    private Jogador jogadorScript;

    void Start ()
    {
        jogadorScript = GameObject.Find("Player").GetComponent<Jogador>();

        alvo = GameObject.Find("Player").GetComponent<Transform>();

        StartCoroutine(FirstShot());

        StartCoroutine(Shoot());
    }
	
	void Update ()
    {
        if (GameObject.Find("Player") != null)
        {
            transform.LookAt(alvo);

            if (jogadorScript.pontuacao == 20)
            {
                cadencia = 4.5f;
            }
            else if (jogadorScript.pontuacao == 25)
            {
                cadencia = 4.0f;
            }
            else if (jogadorScript.pontuacao == 30)
            {
                cadencia = 3.5f;
            }
            else if (jogadorScript.pontuacao == 35)
            {
                cadencia = 3.0f;
            }
        }
	}

    IEnumerator FirstShot()
    {
        yield return new WaitForSeconds(2);
        Instantiate(projetil, transform.position, Quaternion.identity);
    }

    IEnumerator Shoot()
    {
        while (GameObject.Find("Player") != null)
        {
            yield return new WaitForSeconds(cadencia);
            Instantiate(projetil, transform.position, Quaternion.identity);
        }
    }
}
