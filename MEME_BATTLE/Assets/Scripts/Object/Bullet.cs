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
    private Player _actPlayer;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Update()
    {
        Move();
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
            return;
        ObjectPoolManager.Instance.Despawn("Bullet", this.gameObject);
    }
    /***********************************************************************
    *                             Public Methods
    ***********************************************************************/
    #region .
    public void SetTarget(Transform target)
    {
        _targetPos = target.position;
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