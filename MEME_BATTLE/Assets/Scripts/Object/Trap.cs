using UnityEngine;

public class Trap : MonoBehaviour
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/

    #region .

    [SerializeField] private float attackPower;
    private Vector3 targetPos;
    private Player actPlayer;

    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/

    #region .

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
            {
                Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
                rb.AddForce(knockBackDirection * 100, ForceMode2D.Impulse);
            }
            else
            {
                collision.gameObject.AddComponent<Rigidbody2D>();
                Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
                rb.AddForce(knockBackDirection * 100, ForceMode2D.Impulse);
            }
        }
    }

    #endregion
}
