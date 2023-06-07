using UnityEngine;
using UnityEngine.UI;

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

    public MemeCharacter Meme => meme;
    public PlayerType Type => type;

    private void Start()
    {
        if (gameSetManager == null) gameSetManager = GameObject.Find("GameSetManager").GetComponent<GameSetManager>();
        button.onClick.AddListener(() => gameSetManager.SetMeme(this));
        OffButton();
    }
    
    public void OnButton() => button.image.color = new Color(255, 255, 255, 1);
    public void OffButton() => button.image.color = new Color(255, 255, 255, 0.5f);
}
