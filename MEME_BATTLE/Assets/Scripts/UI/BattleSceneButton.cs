using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class BattleSceneButton : MonoBehaviour
    {
        public void MainMenuB()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
