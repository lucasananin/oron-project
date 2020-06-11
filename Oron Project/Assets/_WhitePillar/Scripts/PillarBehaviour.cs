using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarBehaviour : MonoBehaviour
{
    [SerializeField]
    private Color32[] _colors;
    [SerializeField]
    private Light _light;
    [SerializeField]
    private int health = 3;
    //private UIManager _uiManager;
    private PlayerController _playerScript;

	void Start ()
    {
        _light.color = _colors[0];

        //_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //StartCoroutine(HealthRegen());
	}

	void Update ()
    {
		if (health == 10)
        {
            _light.color = _colors[0];
        }
        else if (health == 9)
        {
            _light.color = _colors[1];
        }
        else if (health == 8)
        {
            _light.color = _colors[2];
        }
        else if (health == 7)
        {
            _light.color = _colors[3];
        }
        else if (health == 6)
        {
            _light.color = _colors[4];
        }
        else if (health == 5)
        {
            _light.color = _colors[5];
        }
        else if (health == 4)
        {
            _light.color = _colors[6];
        }
        else if (health == 3)
        {
            _light.color = _colors[7];
        }
        else if (health == 2)
        {
            _light.color = _colors[8];
        }
        else if (health == 1)
        {
            _light.color = _colors[9];
        }
    }

    public void DamageTaken()
    {
        health--;

        if (health < 1 && GameObject.Find("Player") != null)
        {
            //Debug.Log("Pillar Broken");
            //_uiManager.QuitButton();
            _playerScript.DamageTaken();
            _playerScript.DamageTaken();
        }
    }

    /*IEnumerator HealthRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            health++;

            if (health > 3)
            {
                health = 3;
            }
        }
    }*/
}
