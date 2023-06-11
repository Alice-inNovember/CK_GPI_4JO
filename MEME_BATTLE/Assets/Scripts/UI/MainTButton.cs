using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTButton : MonoBehaviour
{
    public GameObject exitConfirmationPanel;
    public Button yesButton;
    public Button noButton;

    void Start()
    {
        yesButton.onClick.AddListener(ExitGame);

        noButton.onClick.AddListener(HideExitConfirmation);
    }

    void Update()
    {
        
    }

    public void OnClickGameStart()
    {
        Debug.Log("Game Start");
    }

    public void OnClickOption()
    {
        SceneManager.LoadScene("Option");
    }

    public void OnClickExit()
    {
        exitConfirmationPanel.SetActive(true);
    }

    public void HideExitConfirmation()
    {
        exitConfirmationPanel.SetActive(false);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
