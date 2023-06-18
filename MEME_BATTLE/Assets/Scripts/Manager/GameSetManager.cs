using UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSetManager : MonoBehaviour
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [SerializeField]
    private Button firstPlayer_DicisionButton;
    [SerializeField]
    private Button secondPlayer_DicisionButton;

    [SerializeField]
    private MemeButton current_firstMemeButton;
    [SerializeField]
    private SkillButton current_firstSkillButton;
    [SerializeField]
    private MemeButton current_secondMemeButton;
    [SerializeField]
    private SkillButton current_secondSkillButton;

    [SerializeField]
    private ReadyUI firstPlayer_ReadyUI;
    [SerializeField]
    private ReadyUI secondPlayer_ReadyUI;

    private bool firstPlayer_Ready;
    private bool secondPlayer_Ready;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Start()
    {
        firstPlayer_DicisionButton.onClick.AddListener(DicisionFirstPlayer);
        secondPlayer_DicisionButton.onClick.AddListener(DicisionSecondPlayer);
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region .
    private void DicisionFirstPlayer()
    {
        if (current_firstMemeButton == null || current_firstSkillButton == null) return;

        PlayerSettings setting = new PlayerSettings(current_firstMemeButton.Meme, current_firstSkillButton.Skill);
        GameSettings.First_PlayerSetting = setting;

        firstPlayer_Ready = true;
        firstPlayer_ReadyUI.gameObject.SetActive(true);
        firstPlayer_ReadyUI.SetMeme(current_firstMemeButton.Meme.sprite);
        TryMovePlayers();
    }

    private void DicisionSecondPlayer()
    {
        if (current_secondMemeButton == null || current_secondSkillButton == null) return;

        PlayerSettings setting = new PlayerSettings(current_secondMemeButton.Meme, current_secondSkillButton.Skill);
        GameSettings.Second_PlayerSetting = setting;

        secondPlayer_Ready = true;
        secondPlayer_ReadyUI.gameObject.SetActive(true);
        secondPlayer_ReadyUI.SetMeme(current_secondMemeButton.Meme.sprite);
        TryMovePlayers();
    }

    private void TryMovePlayers()
    {
        if (firstPlayer_Ready && secondPlayer_Ready)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
    #endregion

    /***********************************************************************
    *                            Public Methods
    ***********************************************************************/
    #region .
    public void SetMeme(MemeButton meme)
    {
        if (meme.Type == PlayerType.First_Player)
        {
            if (current_firstMemeButton != null) current_firstMemeButton.OffButton();
            current_firstMemeButton = meme;
        }
        else
        {
            if (current_secondMemeButton != null) current_secondMemeButton.OffButton();
            current_secondMemeButton = meme;
        }

        meme.OnButton();
    }

    public void SetSkill(SkillButton skill)
    {
        if (skill.Type == PlayerType.First_Player)
        {
            if (current_firstSkillButton != null) current_firstSkillButton.OffButton();
            current_firstSkillButton = skill;
        }
        else
        {
            if (current_secondSkillButton != null) current_secondSkillButton.OffButton();
            current_secondSkillButton = skill;
        }

        skill.OnButton();
    }
    #endregion
}