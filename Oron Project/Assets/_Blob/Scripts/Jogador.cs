using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public float velocidade = 1;
    public int pontuacao = 0;
    public Text textoPts;
    public GameObject coletavel;
    private AudioSource aSource;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        Movimentacao();

        textoPts.text = "" + pontuacao;
	}

    void Movimentacao()
    {
        float movH = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float movV = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.Translate(movH * velocidade, 0, movV * velocidade);

        if (transform.position.x > 5.5f)
        {
            transform.position = new Vector3(5.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -5.5f)
        {
            transform.position = new Vector3(-5.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > 5.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 5.5f);
        }
        else if (transform.position.z < -5.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            pontuacao++;
            aSource.Play();
            Instantiate(coletavel, new Vector3(Random.Range(-3.5f, 3.5f), 0.0f, Random.Range(-3.5f, 3.5f)), Quaternion.identity);
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
}