using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MemeButton : MonoBehaviour
    {
        [SerializeField]
        private GameSetManager gameSetManager;
        [SerializeField]
        private PlayerType type;
        [SerializeField]
        private MemeCharacter meme;
        [SerializeField]
        private Button button;
        [SerializeField]
        private GameObject focus;

        public MemeCharacter Meme => meme;
        public PlayerType Type => type;

        private void Start()
        {
            if (gameSetManager == null) gameSetManager = GameObject.Find("GameSetManager").GetComponent<GameSetManager>();
            button.onClick.AddListener(() => gameSetManager.SetMeme(this));
            OffButton();
        }
    
        public void OnButton() => focus.SetActive(true);
        public void OffButton() => focus.SetActive(false);
    }
}
