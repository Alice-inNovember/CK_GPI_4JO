using System.Collections;
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
    [SerializeField]
    private AudioClip gunshotSound;
    [SerializeField]
    private AudioSource audioSource;

    private bool canShoot;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Start()
    {
        canShoot = true;
    }

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

        if (Input.GetKeyDown(key) && canShoot)
        {
            StartCoroutine(FireBullet());
        }
    }

    private IEnumerator FireBullet()
    {
        GameObject bullet = pool.Spawn("Bullet");

        if (bullet != null)
        {
            audioSource.PlayOneShot(gunshotSound);
            bullet.transform.position = firePivot.position;
            Bullet bl = bullet.GetComponent<Bullet>();
            bl.SetTarget(target);
            canShoot = false;
            yield return new WaitForSeconds(0.2f);
            canShoot = true;
        }
    }
    #endregion
}
