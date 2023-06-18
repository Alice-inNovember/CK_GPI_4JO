using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private GameObject menuPenal;
    [SerializeField] private GameObject creditPenal;
    void Start()
    {
        sfxSlider.value = AudioManager.Instance.SfxVol;
        bgmSlider.value = AudioManager.Instance.BgmVol;
        menuPenal.SetActive(false);
        creditPenal.SetActive(false);
    }

    public void MenuOpenB()
    {
        menuPenal.SetActive(true);
    }

    public void MenuCloseB()
    {
        menuPenal.SetActive(false);
    }
    
    public void CreditOpenB()
    {
        creditPenal.SetActive(true);
    }

    public void CreditCloseB()
    {
        creditPenal.SetActive(false);
    }
    public void ExitGameB()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void StartB()
    {
        SceneManager.LoadScene("Scenes/PlayerSettingScene");
    }

    public void SfxVolS()
    {
        AudioManager.Instance.SfxVol = sfxSlider.value;
        Debug.Log(AudioManager.Instance.SfxVol);
    }

    public void BgmVolS()
    {
        AudioManager.Instance.BgmVol = bgmSlider.value;
        Debug.Log(AudioManager.Instance.BgmVol);
    }
}
