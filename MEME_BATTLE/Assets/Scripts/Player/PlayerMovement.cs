using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    /***********************************************************************
    *                           Components Required
    ***********************************************************************/
    #region .
    [SerializeField]
    private Player player;
    [SerializeField]
    private Rigidbody2D rigid;
    #endregion

    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [Header("Character Fields")]
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    [Header("Ground Fields")]
    [SerializeField]
    private Vector2 groundBox = new Vector2();
    [SerializeField]
    private float groundRayDistance = 1.0f;
    [SerializeField]
    private LayerMask groundLayer;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Awake()
    {
        if (rigid == null)
        {
            TryGetComponent(out Rigidbody2D rigidbody);
            rigid = rigidbody;
        }
    }

    private void Update()
    {
        OnKeyborad();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y - groundRayDistance, transform.position.z), groundBox);
    }
    #endregion

    /***********************************************************************
    *                             Private Methods
    ***********************************************************************/
    #region .
    private bool IsPlayerOnGround()
    {
        RaycastHit2D GroundObj = Physics2D.BoxCast(transform.position, groundBox, 0f, Vector2.down, groundRayDistance, groundLayer);

        return GroundObj.collider != null;
    }

    private void OnKeyborad()
    {
        if (player.Type == 0)
        {
            if (Input.GetKeyUp(InputManager.Player01[EKey.Left]) || Input.GetKeyUp(InputManager.Player01[EKey.Right]))
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
            }

            if (Input.GetKey(InputManager.Player01[EKey.Left]))
            {
                rigid.velocity = new Vector3(-1 * moveSpeed, rigid.velocity.y);
            }
            if (Input.GetKey(InputManager.Player01[EKey.Right]))
            {
                rigid.velocity = new Vector3(1 * moveSpeed, rigid.velocity.y);
            }
            if (Input.GetKeyDown(InputManager.Player01[EKey.Jump]))
            {
                if (IsPlayerOnGround()) rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            }
        }
        else
        {
            if (Input.GetKeyUp(InputManager.Player02[EKey.Left]) || Input.GetKeyUp(InputManager.Player02[EKey.Right]))
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
            }

            if (Input.GetKey(InputManager.Player02[EKey.Left]))
            {
                rigid.velocity = new Vector3(-1 * moveSpeed, rigid.velocity.y);
            }
            if (Input.GetKey(InputManager.Player02[EKey.Right]))
            {
                rigid.velocity = new Vector3(1 * moveSpeed, rigid.velocity.y);
            }
            if (Input.GetKeyDown(InputManager.Player02[EKey.Jump]))
            {
                if (IsPlayerOnGround()) rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            }
        }
    }
    #endregion

    /***********************************************************************
    *                             Public Methods
    ***********************************************************************/
    #region .
    public void AddJumpForce(int value) => jumpForce += value;
    public void AddMoveSpeed(int value) => moveSpeed += value;
    #endregion
}