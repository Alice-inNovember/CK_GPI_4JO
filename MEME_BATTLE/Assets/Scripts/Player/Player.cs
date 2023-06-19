using Manager;
using System.Collections;
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
    [Header("Player Components")]
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private PlayerMovement pm;
    [SerializeField]
    private BattleManager bm;
    [SerializeField]
    private GameManager gm;
    [SerializeField]
    private Rigidbody2D rigid;

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

        // Scriptable Object�� �� ����
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
            {
                Attack();
            }
            else
            {
                collision.gameObject.AddComponent<Rigidbody2D>();
                Attack();
            }
        }
        else if (collision.transform.CompareTag("KillWall"))
        {
            RemoveLife(1);
            this.rigid.velocity = new Vector2(0, 0);
            bm.Respawn(Type == PlayerType.First_Player);
        }

        void Attack()
        {
            Vector2 knockBackDirection = (transform.position - collision.transform.position).normalized;
            float _attackPower = SetAttackPower();

            if (_attackPower > 100)
            {
                this.rigid.velocity = new Vector2(0, 0);
                bm.Respawn(Type == PlayerType.First_Player);
            }

            rigid.AddForce(knockBackDirection * _attackPower, ForceMode2D.Impulse);
            AddHitCount(1);
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
            sr.sprite = GameSettings.First_PlayerSetting.Meme.sprite;
        }
        else
        {
            meme = GameSettings.Second_PlayerSetting.Meme;
            skill = GameSettings.Second_PlayerSetting.Skill;
            sr.sprite = GameSettings.Second_PlayerSetting.Meme.sprite;
        }

        hitCount = 0;
    }

    private int SetAttackPower()
    {
        if (hitCount <= 0) hitCount = 1;
        return (atk * hitCount) / weight;
    }
    #endregion

    /***********************************************************************
    *                            Public Methods
    ***********************************************************************/
    #region .
    public void AddLife(byte value) => life += value;
    public void RemoveLife(byte value)
    {
        life -= value;

        if (life == 0)
        {
            gm.GameOver(type != PlayerType.First_Player);
        }

        gm.SetDisplayLife(life, type == PlayerType.First_Player);
    }
    public void AddAttack(int value) => atk += value;
    public void AddJumpForce(int value) => pm.AddJumpForce(value);
    public void AddMoveSpeed(int value) => pm.AddMoveSpeed(value);
    public void AddHitCount(int value)
    {
        hitCount += value;
        gm.SetHitCountNbr(hitCount, type == PlayerType.First_Player);
    }
    public void SetHitCount(int value)
    {
        hitCount = value;
        gm.SetHitCountNbr(hitCount, type == PlayerType.First_Player);
    }
    #endregion
}
