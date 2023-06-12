using UnityEngine;

public enum PlayerType
{
    First_Player,
    Second_Player
}

public static class GameSettings
{
    public static PlayerSettings First_PlayerSetting;
    public static PlayerSettings Second_PlayerSetting;
}

[System.Serializable]
public class PlayerSettings
{
    public MemeCharacter Meme { get; private set; }
    public PassiveSkill Skill { get; private set; }

    public PlayerSettings(MemeCharacter meme, PassiveSkill skill)
    {
        Meme = meme;
        Skill = skill;
    }
}

public class Player : MonoBehaviour
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [Header("Player Infos")]
    [SerializeField]
    private PlayerType type;
    [SerializeField]
    private MemeCharacter meme;
    [SerializeField]
    private PassiveSkill skill;

    [Header("Player Stats")]
    [SerializeField]
    private byte life;
    [SerializeField]
    private int atk;
    [SerializeField]
    private int weight;
    [SerializeField]
    private int hitCount;
    #endregion

    /***********************************************************************
    *                             Public Fields
    ***********************************************************************/
    #region .
    public byte Life => life;
    public int Atk => atk;
    public int Weight => weight;
    public PlayerType Type => type;
    public int HitCount => hitCount;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Awake()
    {
        Initialize();

        // Scriptable Object의 값 대입
        life = meme.life;
        atk = meme.attackPower;
        weight = meme.weight;
    }

    private void Start()
    {
        if (skill.type == PassiveType.Start)
        {
            skill.Execute(this);
        }
    }

    private void Update()
    {
        if (skill.type == PassiveType.Update)
        {
            skill.Execute(this);
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region .
    private void Initialize()
    {
        if (GameSettings.First_PlayerSetting == null || GameSettings.Second_PlayerSetting == null) return;

        if (type == PlayerType.First_Player)
        {
            meme = GameSettings.First_PlayerSetting.Meme;
            skill = GameSettings.First_PlayerSetting.Skill;
        }
        else
        {
            meme = GameSettings.Second_PlayerSetting.Meme;
            skill = GameSettings.Second_PlayerSetting.Skill;
        }

        hitCount = 0;
    }
    #endregion

    /***********************************************************************
    *                            Public Methods
    ***********************************************************************/
    #region .
    public void AddLife(byte value) => life += value;
    public void RemoveLife(byte value) => life -= value;
    public void AddAttack(int value) => atk += value;
    #endregion
}
