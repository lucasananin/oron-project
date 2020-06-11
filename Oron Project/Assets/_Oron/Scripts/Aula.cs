using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aula : MonoBehaviour
{
    /*float n1, n2, media;
    string msg1 = "Aprovado: ";
    string msg2 = "Recuperacao: ";
    string msg3 = "Reprovado: ";
    int estado;*/

    // Use this for initialization
    void Start()
    {
        // IF ELSE;
        /*n1 = 4.5f;
        n2 = 1f;
        media = (n1 + n2) / 2;
        media = (int)media;

        if (media >= 7)
        {
            print (msg1 + media);
        }
        else if (media < 7 && media >= 4)
        {
            print (msg2 + media);
        }
        else
        {
            print (msg3 + media);
        }

        // SWITCH;
        estado = 2;
        switch (estado)
        {
            case 1:
                print(estado + ": Ataque");
                break;
            case 2:
                print(estado + ": Defesa");
                break;
            default:
                print(estado + ": Esquiva");
                break;
        }

        // FOR;
        for (int i=1; i<4; i++)
        {
            print("For: " + i);
        }

        // WHILE;
        int z = 1;
        while (z < 4)
        {
            print("While: " + z);
            z++;
        }

        // FOREACH;
        int[] casa = new int[4];
        casa[0] = 10;
        casa[1] = 20;
        casa[2] = 30;
        casa[3] = 40;

        foreach (int valor in casa)
        {
            print(valor);
                if (valor == 20)
                {
                    continue;
                }
            print("Ok");
        }

        // VETOR;
        string[] aluno = new string[4];
        aluno[0] = "Afonso";
        aluno[1] = "Beatriz";
        aluno[2] = "Camila";
        aluno[3] = "Edgar";

        foreach (string estudante in aluno)
        {
            print (estudante);
        }

        int v1 = 0, str = 0;
        print(v1 < 1 ? "Sim" : "Nao");
        print(v1 < 1 ? str+=1 : str-=1);
        str++;
        str++;
        str--;
        print(str);

        // LISTA;
        List<int> itens = new List<int>();

        for (int it = 0; it <= 5; it++)
        {
            itens.Add(it);
        }

        itens.Remove(2);// remove o valor
        itens.Remove(3);

        foreach (int valores in itens)
        {
            print("Casa: " + valores);
        }

        print("Valor: " + itens[3]);//mostra o valor na chave 
        print("Chave: " + itens.IndexOf(5));// mostra a chave do valor

        // DICIONARIO;
        Dictionary<string, string> vilao = new Dictionary<string, string>();
        vilao.Add("Gilgamesh", "Chefe 1");
        vilao.Add("Ultima", "Chefe 2");

        foreach(string chave in vilao.Keys)
        {
            print(vilao[chave]);
        }*/

        // RPG;
        /*Random rnd = new Random();
        int pHp = Random.Range(60, 121);
        print("Player HP: " + pHp);
        int eHp = Random.Range(60, 121);
        print("Enemy HP: " + eHp);
        int rodada = Random.Range(0, 2);
        print("Rodada: " + rodada);

        while (pHp > 0 && eHp > 0)
        {
            if (rodada == 0) // Jogador ataca primeiro
            {
                int pDmg = Random.Range(10, 31);
                eHp -= pDmg;
                print("Jogador causou " + pDmg + " de dano, Inimigo possui " + eHp + " de vida;");
                if (eHp < 1)
                {
                    break;
                }
                int eDmg = Random.Range(10, 31);
                pHp -= eDmg;
                print("Inimigo causou " + eDmg + " de dano, Jogador possui " + pHp + " de vida;");
            }
            else // Inimigo ataca primeiro
            {
                int eDmg = Random.Range(10, 31);
                pHp -= eDmg;
                print("Inimigo causou " + eDmg + " de dano, Jogador possui " + pHp + " de vida;");
                if (pHp < 1)
                {
                    break;
                }
                int pDmg = Random.Range(10, 31);
                eHp -= pDmg;
                print("Jogador causou " + pDmg + " de dano, Inimigo possui " + eHp + " de vida;");
            }
        }
        if (pHp > 0)
        {
            print("Vitoria;");
        }
        else
        {
            print("Derrota;");
        }*/

    }

    // Update is called once per frame
    void Update()
    {

    }
}