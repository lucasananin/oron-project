using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _manaText;
    [SerializeField]
    private Text _playTimeText;

    [SerializeField]
    private GameObject _pausePanel;
    public bool _isGameRunning = true;
    private bool _isUIActive = true;

    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private AudioSource _audioSource;
    private SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnPoint").GetComponent<SpawnManager>();

        Time.timeScale = 1.0f;

        _isGameRunning = true;

        CursorController();
    }

    private void Update()
    {
        UIDisplay();

        if (Input.GetKeyDown(KeyCode.Escape) && _isGameRunning == true)
        {
            _audioSource.Play();
            PauseButton();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isGameRunning == false)
        {
            _audioSource.Play();
            ResumeButton();
        }
    }

    private void UIDisplay()
    {
        if (Input.GetKeyDown(KeyCode.I) && _isUIActive == true)
        {
            _manaText.gameObject.SetActive(false);
            _playTimeText.gameObject.SetActive(false);
            _isUIActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.I) && _isUIActive == false)
        {
            _manaText.gameObject.SetActive(true);
            _playTimeText.gameObject.SetActive(true);
            _isUIActive = true;
        }
    }

    public void CursorController()
    {
        if (_isGameRunning == true)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    public void PauseButton()
    {
        _pausePanel.SetActive(true);
        _isGameRunning = false;
        Time.timeScale = 0f;
        CursorController();
    }

    public void ResumeButton()
    {
        _pausePanel.SetActive(false);
        _isGameRunning = true;
        //Time.timeScale = 1.0f;
        Time.timeScale = _spawnManager.timeScale;
        CursorController();
    }

    public void QuitButton()
    {
        StartCoroutine(GameEnds());
    }

    public void QuitButton2()
    {
        SceneManager.LoadScene("MainMenu");
        _isGameRunning = false;
        Time.timeScale = 1f;
        CursorController();
    }

    public void UpdateMana(int currentMana)
    {
        _manaText.text = "" + currentMana;
    }

    public void UpdateTime()
    {
        _playTimeText.text = "" + (int)Time.timeSinceLevelLoad;
    }

    IEnumerator GameEnds()
    {
        yield return new WaitForSeconds(3);
        _anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
        _isGameRunning = false;
        Time.timeScale = 1f;
        CursorController();
    }
}
