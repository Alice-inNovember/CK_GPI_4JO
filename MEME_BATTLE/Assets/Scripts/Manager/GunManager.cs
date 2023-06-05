using TMPro;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [SerializeField]
    private Player player;
    [SerializeField]
    private ObjectPoolManager pool;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform firePivot;
    [SerializeField]
    private float bulletSpeed;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Update()
    {
        RotateTowardsTarget();
        TryAttack();
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region .
    private void RotateTowardsTarget()
    {
        Vector3 difference = target.position - transform.position;
        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }

    private void TryAttack()
    {
        KeyCode key;

        if (player.Type == PlayerType.First_Player) key = InputManager.Player01[EKey.Action1];
        else key = InputManager.Player02[EKey.Action1];

        if (Input.GetKeyDown(key))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = pool.Spawn("Bullet");
        if (bullet != null)
        {
            bullet.transform.position = firePivot.position;
            Bullet bl = bullet.GetComponent<Bullet>();
            bl.SetValue(player, target);
        }
    }
    #endregion
}
