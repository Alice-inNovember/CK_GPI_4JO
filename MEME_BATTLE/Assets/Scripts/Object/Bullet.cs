using UnityEngine;

public class Bullet : MonoBehaviour
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [SerializeField]
    private float speed;
    private float _attackPower;
    private Vector3 _targetPos;
    private Player _actPlayer;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Player"))
        {
            if (collision.transform.CompareTag("Player"))
            {
                if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
                {
                    Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
                    rb.AddForce(knockBackDirection * _attackPower, ForceMode2D.Impulse);
                    if (collision.TryGetComponent(out Player player))
                    {
                        _actPlayer.AddHitCount(1);
                    }
                }
                else
                {
                    collision.gameObject.AddComponent<Rigidbody2D>();
                    Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
                    rb.AddForce(knockBackDirection * _attackPower, ForceMode2D.Impulse);
                    if (collision.TryGetComponent(out Player player))
                    {
                        _actPlayer.AddHitCount(1);
                    }
                }
            }

            ObjectPoolManager.Instance.Despawn("Bullet", gameObject);
        }
    }

    private void Update()
    {
        Move();
    }
    #endregion

    /***********************************************************************
    *                             Public Methods
    ***********************************************************************/
    #region .
    public void SetValue(Player player, Transform target)
    {
        int hitCount = player.HitCount;
        if (hitCount <= 0) hitCount = 1;
        _attackPower = (player.Atk * hitCount) / player.Weight;
        _targetPos = target.position;
        _actPlayer = player;
    }

    public void Move()
    {
        Vector3 directionToTarget = _targetPos - transform.position;
        float distance = directionToTarget.magnitude;

        if (distance <= speed * Time.deltaTime)
        {
            ObjectPoolManager.Instance.Despawn("Bullet", gameObject);
            return;
        }

        transform.Translate(speed * Time.deltaTime * directionToTarget.normalized, Space.World);
    }
    #endregion
}
