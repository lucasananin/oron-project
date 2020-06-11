using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Objetos;
    [SerializeField]
    private GameObject[] _bullets;
    [SerializeField]
    private GameObject[] _particles;

    // Atributos;
    [SerializeField]
    private float _movSpeed = 1;
    public int health = 2;
    [SerializeField]
    private int _mana = 0;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextFire = 0.0f;

    //Interface;
    private UIManager _uiManager;

    // Material;
    [SerializeField]
    private Material _material;
    [SerializeField]
    private Texture _amarelo;
    [SerializeField]
    private Texture _vermelho;
    /*[SerializeField]
    private Color32 _amarelo;
    [SerializeField]
    private Color32 _vermelho;*/

    void Start ()
    {
        _material.mainTexture = _amarelo;

        StartCoroutine(ManaRegeneration());

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.UpdateMana(_mana);
        }
	}
	
	void Update ()
    {
        Movement();

        Shoot();

        _uiManager.UpdateTime();

        _uiManager.UpdateMana(_mana);
    }

    void Movement()
    {
        float movHorizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * _movSpeed * movHorizontal * Time.deltaTime);

        if (transform.position.x > 6)
        {
            transform.position = new Vector3(6, 0, transform.position.z);
        }
        else if (transform.position.x < -6)
        {
            transform.position = new Vector3(-6, 0, transform.position.z);
        }

        /*if (transform.position.x > 8)
        {
            transform.position = new Vector3(-8, 0, transform.position.z);
        }
        else if (transform.position.x < -8)
        {
            transform.position = new Vector3(8, 0, transform.position.z);
        }*/
    }

    void Shoot()
    {
        if (_uiManager._isGameRunning == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (Time.time >= _nextFire)
                {
                    _nextFire = Time.time + _fireRate;
                    Instantiate(_bullets[0], transform.position, Quaternion.identity);
                }
            }
            else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Z))
            {
                if (_mana >= 2)
                {
                    Instantiate(_bullets[1], transform.position, Quaternion.identity);
                    _mana -= 2;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.X))
            {
                if (_mana >= 4)
                {
                    Instantiate(_bullets[2], transform.position, Quaternion.identity);
                    _mana -= 4;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.C))
            {
                if (_mana >= 6)
                {
                    Instantiate(_bullets[3], new Vector3(0, 0, 0), Quaternion.identity);
                    _mana -= 6;
                }
            }
        }
    }

    public void DamageTaken()
    {
        health--;
        StartCoroutine(HealthRegeneration());
        _material.mainTexture = _vermelho;

        if (health < 1)
        {
            Instantiate(_particles[0], transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            //SceneManager.LoadScene("MainMenu");
            _uiManager.QuitButton();
        }
    }

    IEnumerator HealthRegeneration()
    {
        yield return new WaitForSeconds(3);
        health++;
        _material.mainTexture = _amarelo;
    }

    IEnumerator ManaRegeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            _mana++;

            if (_mana >= 7)
            {
                _mana = 7;
            }
        }
    }

    private void OnDestroy()
    {
        _material.mainTexture = _amarelo;
    }

    private void OnApplicationQuit()
    {
        _material.mainTexture = _amarelo;
    }
}