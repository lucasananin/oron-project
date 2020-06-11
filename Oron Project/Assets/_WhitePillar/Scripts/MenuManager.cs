using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button[] _systemButtons;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private AudioMixer _audioMixer;

    void Start()
    {
        Time.timeScale = 1.0f;

        //QualitySettings.vSyncCount = 1;
        //QualitySettings.shadows = ShadowQuality.HardOnly;
    }

    private void Update()
    {
        ActiveButtons();
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene("Intro");
        _anim.SetTrigger("FadeOut");
        StartCoroutine(LoadIntro());
    }

    IEnumerator LoadIntro()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Intro");
    }

    private void ActiveButtons()
    {
        if (QualitySettings.vSyncCount == 1)
        {
            _systemButtons[1].gameObject.SetActive(true);
            _systemButtons[0].gameObject.SetActive(false);
        }
        else if (QualitySettings.vSyncCount == 0)
        {
            _systemButtons[1].gameObject.SetActive(false);
            _systemButtons[0].gameObject.SetActive(true);
        }

        /*if (QualitySettings.shadows == ShadowQuality.HardOnly)
        {
            _systemButtons[3].gameObject.SetActive(true);
            _systemButtons[2].gameObject.SetActive(false);
        }
        else if (QualitySettings.shadows == ShadowQuality.Disable)
        {
            _systemButtons[3].gameObject.SetActive(false);
            _systemButtons[2].gameObject.SetActive(true);
        }*/
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void VsyncOFF()
    {
        QualitySettings.vSyncCount = 0;
    }

    public void VsyncON()
    {
        QualitySettings.vSyncCount = 1;
    }

    public void VolumeOFF()
    {
        _audioMixer.SetFloat("masterVolume", -80);
    }

    public void VolumeON()
    {
        _audioMixer.SetFloat("masterVolume", 0);
    }

    /*public void ShadowOFF()
    {
        QualitySettings.shadows = ShadowQuality.Disable;
    }

    public void ShadowON()
    {
        QualitySettings.shadows = ShadowQuality.HardOnly;
    }*/
}
