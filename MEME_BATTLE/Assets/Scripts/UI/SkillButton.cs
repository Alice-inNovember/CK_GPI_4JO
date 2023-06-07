using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private GameSetManager gameSetManager;
    [SerializeField]
    private PlayerType type;
    [SerializeField]
    private PassiveSkill skill;
    [SerializeField]
    private Button button;

    public PassiveSkill Skill => skill;
    public PlayerType Type => type;

    private void Start()
    {
        if (gameSetManager == null) gameSetManager = GameObject.Find("GameSetManager").GetComponent<GameSetManager>();
        button.onClick.AddListener(() => gameSetManager.SetSkill(this));
        OffButton();
    }

    public void OnButton() => button.image.color = new Color(255, 255, 255, 255);
    public void OffButton() => button.image.color = new Color(255, 255, 255, 0.5f);
}