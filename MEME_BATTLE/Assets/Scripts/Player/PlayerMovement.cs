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
    private float jumpForce = 20f;

    [Header("Ground Fields")]
    [SerializeField]
    private Vector2 groundBox = new Vector2();
    [SerializeField]
    private float groundRayDistance = 1.0f;
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private bool canMove;
    #endregion

    /***********************************************************************
    *                             Public Fields
    ***********************************************************************/
    #region .
    public bool CanMove => canMove;
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    private void Awake()
    {
        if (rigid == null)
        {
            TryGetComponent(out Rigidbody2D component);
            rigid = component;
        }

        canMove = true;
    }

    private void Update()
    {
        OnKeyboard();
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

    private void OnKeyboard()
    {
        if (InputManager.Player01.Count == 0) new InputManager().SetDefault();

        if (canMove)
        {
            if (player.Type == 0)
            {
                if (Input.GetKey(InputManager.Player01[EKey.Left]))
                {
                    transform.position += new Vector3(-1 * moveSpeed, 0) * Time.deltaTime;
                }
                if (Input.GetKey(InputManager.Player01[EKey.Right]))
                {
                    transform.position += new Vector3(1 * moveSpeed,0) * Time.deltaTime;
                }
                if (Input.GetKeyDown(InputManager.Player01[EKey.Jump]))
                {
                    if (IsPlayerOnGround())
                    {
                        rigid.velocity = Vector2.up * jumpForce;
                    }
                }
            }
            else
            {
                if (Input.GetKey(InputManager.Player02[EKey.Left]))
                {
                    transform.position += new Vector3(-1 * moveSpeed,0) * Time.deltaTime;
                }
                if (Input.GetKey(InputManager.Player02[EKey.Right]))
                {
                    transform.position += new Vector3(1 * moveSpeed, 0) * Time.deltaTime;
                }
                if (Input.GetKeyDown(InputManager.Player02[EKey.Jump]))
                {
                    if (IsPlayerOnGround())
                    {
                        rigid.velocity = Vector2.up * jumpForce;
                    }
                }
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
    public void SetMove(bool move) => canMove = move;
    #endregion
}