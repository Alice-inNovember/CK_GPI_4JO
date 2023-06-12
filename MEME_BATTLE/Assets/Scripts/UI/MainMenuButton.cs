using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject menuPenal;
    [SerializeField] private GameObject creditPenal;
    void Start()
    {
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
}
