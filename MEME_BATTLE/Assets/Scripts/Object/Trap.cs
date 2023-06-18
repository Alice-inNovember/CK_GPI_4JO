using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float attackPower;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
            {
                Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
                rb.AddForce(knockBackDirection * attackPower, ForceMode2D.Impulse);
            }
            else
            {
                collision.gameObject.AddComponent<Rigidbody2D>();
                Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
                rb.AddForce(knockBackDirection * attackPower, ForceMode2D.Impulse);
            }
        }
    }
}
