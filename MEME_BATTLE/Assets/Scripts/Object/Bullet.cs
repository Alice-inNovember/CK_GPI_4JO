using UnityEngine;

public class Bullet : MonoBehaviour
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [SerializeField]
    private float speed;
    [SerializeField]
    private float attackPower;
    private Vector3 targetPos;
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
                    Debug.Log(attackPower);
                    rb.AddForce(knockBackDirection * attackPower, ForceMode2D.Impulse);
                }
                else
                {
                    collision.gameObject.AddComponent<Rigidbody2D>();
                    Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
                    rb.AddForce(knockBackDirection * attackPower, ForceMode2D.Impulse);
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
        attackPower = (player.Atk * hitCount) / player.Weight;
        targetPos = target.position;
    }

    public void Move()
    {
        Vector3 directionToTarget = targetPos - transform.position;
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
