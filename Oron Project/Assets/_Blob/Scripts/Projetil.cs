using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : Jogador
{
    private Transform alvo;
    private Interface uiScript;
    private Gerenciador gScript;
    public GameObject particulinha;
    public GameObject jogadorParticle;

	void Start ()
    {
        alvo = GameObject.Find("Player").GetComponent<Transform>();

        uiScript = GameObject.Find("Canvas").GetComponent<Interface>();

        gScript = GameObject.Find("Gerenciador").GetComponent<Gerenciador>();

        transform.LookAt(alvo);

        Destroy(this.gameObject, 5);
    }
	
	void Update ()
    {
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(jogadorParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            uiScript.victoryText.SetActive(false);
            uiScript.loseText.SetActive(true);
            gScript.FimdeJogo();
        }
        else
        {
            Instantiate(particulinha, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
