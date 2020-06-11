using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private float _introTime;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private AudioSource _audioSource;
    private bool _isKeyPressed;

	void Start ()
    {
        Time.timeScale = 1.0f;

        //StartCoroutine(IntroEnds());
        Cursor.visible = false;
        _isKeyPressed = false;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene("Game");
            _anim.SetTrigger("FadeOut");
            StartCoroutine(IntroEnds());

            if (_isKeyPressed == false)
            {
                _audioSource.Play();
                _isKeyPressed = true;
            }
        }
	}

    IEnumerator IntroEnds()
    {
        //yield return new WaitForSeconds(_introTime);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }
}
