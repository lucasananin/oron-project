using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _bullets;
    [SerializeField]
    private GameObject[] _particles;
    [SerializeField]
    private float _movSpeed = 1;
    public int health = 1;
    [SerializeField]
    private float _fireRate = 1.0f;
    private float _nextFire = 0;
    [SerializeField]
    private int _enemyID = 0;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(Random.Range(-6.0f, 6.0f), 0, 16);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_enemyID == 0 || _enemyID == 1)
        {
            Enemy0Behaviour();
        }
        else if (_enemyID == 2)
        {
            Enemy2Behaviour();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerScript = other.GetComponent<PlayerController>();

            if (playerScript != null)
            {
                playerScript.DamageTaken();
            }

            this.DamageTaken();
        }
        else if (other.gameObject.CompareTag("Pillar"))
        {
            PillarBehaviour pillarScript = other.GetComponent<PillarBehaviour>();

            if (pillarScript != null)
            {
                pillarScript.DamageTaken();
            }
        }
    }

    public void DamageTaken()
    {
        health--;

        if (health <= 0)
        {
            Instantiate(_particles[0], transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void Enemy0Behaviour()
    {
        transform.Translate(Vector3.back * _movSpeed * Time.deltaTime);

        if (transform.position.z < -4)
        {
            Destroy(this.gameObject);
            //transform.position = new Vector3(Random.Range(-6.0f, 6.0f), 0, 16);
        }
    }

    private void Enemy2Behaviour()
    {
        transform.Translate(Vector3.back * _movSpeed * Time.deltaTime);

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (transform.position.z < 10)
            {
                transform.position = new Vector3(transform.position.x, 0, 10);

                if (Time.time > _nextFire)
                {
                    _nextFire = Time.time + _fireRate;
                    Instantiate(_bullets[0], transform.position + Vector3.back, Quaternion.identity);
                }
            }
        }
        else if (transform.position.z < -4)
        {
            Destroy(this.gameObject);
        }
    }
}
