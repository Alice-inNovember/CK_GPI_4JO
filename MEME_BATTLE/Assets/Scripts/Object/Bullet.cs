using UnityEngine;

public class Bullet : MonoBehaviour
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [SerializeField]
    private float speed = 40;
    private float _attackPower;
    private Vector3 _targetPos;
    private Vector3 directionToTarget;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) return;

        ObjectPoolManager.Instance.Despawn("Bullet", this.gameObject);
    }
    #endregion
    /***********************************************************************
    *                             Public Methods
    ***********************************************************************/
    #region .
    public void SetTarget(Transform target)
    {
        _targetPos = target.position;
        directionToTarget = (_targetPos - transform.position).normalized;
    }

    public void Move()
    {
        transform.position += speed * Time.deltaTime * directionToTarget;
    }
    #endregion
}