using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _particles;
    [SerializeField]
    private Transform _playerTarget;
    [SerializeField]
    private float _movSpeed = 1;
    [SerializeField]
    private int _bulletID = 0;
    /*[SerializeField]
    private int phalanxHealth = 1;*/

	void Start ()
    {
        if (_bulletID == 0)
        {
            Destroy(this.gameObject, 2.5f);
        }
        else if (_bulletID == 1)
        {
            Destroy(this.gameObject, 2.5f);
        }
		else if (_bulletID == 2)
        {
            StartCoroutine(PhalanxOFF());
        }
        else if (_bulletID == 3)
        {
            Destroy(this.gameObject, 2.5f);
        }
        else if (_bulletID == 4)
        {
            //Destroy(this.gameObject, 4.0f);

            if (GameObject.Find("Player") != null)
            {
                _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
            }

            transform.LookAt(_playerTarget);
        }
	}

	void Update ()
    {
        if (_bulletID != 2)
        {
            transform.Translate(Vector3.forward * _movSpeed * Time.deltaTime);

            /*if (transform.position.z > 16 || transform.position.z < -4)
            {
                Destroy(this.gameObject);
            }*/
            if (transform.position.z < -4)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && _bulletID == 0)
        {
            EnemyAI enemyScript = other.GetComponent<EnemyAI>();

            if (enemyScript != null)
            {
                enemyScript.DamageTaken();
            }

            //Instantiate(_particles[0], transform.position + Vector3.forward, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy") && _bulletID == 1)
        {
            EnemyAI enemyScript = other.GetComponent<EnemyAI>();

            if (enemyScript != null)
            {
                enemyScript.DamageTaken();
            }
        }
        else if (other.gameObject.CompareTag("Enemy") && _bulletID == 2)
        {
            EnemyAI enemyScript = other.GetComponent<EnemyAI>();

            if (enemyScript != null)
            {
                enemyScript.DamageTaken();
            }

            /*Destroy(other.gameObject);
            phalanxHealth--;

            if (phalanxHealth < 1)
            {
                Destroy(this.gameObject);
            }*/
        }
        else if (other.gameObject.CompareTag("Enemy") && _bulletID == 3)
        {
            EnemyAI enemyScript = other.GetComponent<EnemyAI>();

            if (enemyScript != null)
            {
                enemyScript.DamageTaken();
            }

            //Instantiate(_particles[0], transform.position + Vector3.forward, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && _bulletID == 4)
        {
            PlayerController playerScript = other.GetComponent<PlayerController>();

            if (playerScript != null)
            {
                playerScript.DamageTaken();
            }

            Instantiate(_particles[0], transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Shield") && _bulletID == 4)
        {
            //PlayerController playerScript = other.GetComponent<PlayerController>();

            /*if (playerScript != null)
            {
                playerScript.DamageTaken();
            }*/

            Instantiate(_particles[0], transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator PhalanxOFF()
    {
        yield return new WaitForSeconds(10);
        Instantiate(_particles[0], transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
