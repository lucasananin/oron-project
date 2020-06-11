using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemiesPrefab;
    private float _nextEnemy0;
    private float _nextEnemy1;
    private float _nextEnemy2;
    public float timeScale = 1.0f;

	void Start ()
    {
        StartCoroutine(Enemy0Spawn());
        StartCoroutine(Enemy1Spawn());
        StartCoroutine(Enemy2Spawn());

        _nextEnemy0 = 2.0f;
        _nextEnemy1 = 4.0f;
        _nextEnemy2 = 6.0f;
    }
	
	void Update ()
    {
        if ((int)Time.timeSinceLevelLoad == 60)
        {
            _nextEnemy0 = 1.5f;
            _nextEnemy1 = 3.5f;
            _nextEnemy2 = 5.5f;
        }
        else if ((int)Time.timeSinceLevelLoad == 80)
        {
            _nextEnemy0 = 1.0f;
            _nextEnemy1 = 3.0f;
            _nextEnemy2 = 5.0f;
        }
        else if ((int)Time.timeSinceLevelLoad == 100)
        {
            _nextEnemy0 = 1.0f;
            _nextEnemy1 = 2.5f;
            _nextEnemy2 = 4.5f;
        }
        else if ((int)Time.timeSinceLevelLoad == 120)
        {
            _nextEnemy0 = 1.0f;
            _nextEnemy1 = 2.0f;
            _nextEnemy2 = 4.0f;
        }
        else if ((int)Time.timeSinceLevelLoad == 140)
        {
            _nextEnemy0 = 1.0f;
            _nextEnemy1 = 2.0f;
            _nextEnemy2 = 3.5f;
        }
        else if ((int)Time.timeSinceLevelLoad == 160)
        {
            _nextEnemy0 = 1.0f;
            _nextEnemy1 = 2.0f;
            _nextEnemy2 = 3.0f;
        }
        else if ((int)Time.timeSinceLevelLoad == 200)
        {
            Time.timeScale = 1.1f;
            timeScale = 1.1f;
        }
        else if ((int)Time.timeSinceLevelLoad == 240)
        {
            Time.timeScale = 1.2f;
            timeScale = 1.2f;
        }
        else if ((int)Time.timeSinceLevelLoad == 280)
        {
            Time.timeScale = 1.3f;
            timeScale = 1.3f;
        }
        else if ((int)Time.timeSinceLevelLoad == 320)
        {
            Time.timeScale = 1.4f;
            timeScale = 1.4f;
        }
        else if ((int)Time.timeSinceLevelLoad == 360)
        {
            Time.timeScale = 1.5f;
            timeScale = 1.5f;
        }
    }

    IEnumerator Enemy0Spawn()
    {
        yield return new WaitForSeconds(5);

        while (true)
        {
            Instantiate(_enemiesPrefab[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_nextEnemy0);
        }
    }

    IEnumerator Enemy1Spawn()
    {
        yield return new WaitForSeconds(20);

        while (true)
        {
            Instantiate(_enemiesPrefab[1], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_nextEnemy1);
        }
    }

    IEnumerator Enemy2Spawn()
    {
        yield return new WaitForSeconds(40);

        while (true)
        {
            Instantiate(_enemiesPrefab[2]);
            yield return new WaitForSeconds(_nextEnemy2);
        }
    }
}
