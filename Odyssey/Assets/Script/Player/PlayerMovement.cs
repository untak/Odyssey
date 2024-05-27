using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigid;

    [Header("ÀÌµ¿")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Á¡ÇÁ")]
    [SerializeField] float jumpForce = 10;
    bool isGrounded = true;

    [Header("³«ÇÏ")]
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    [SerializeField] float raycastDistance = 1.1f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public PlayerMovement(Rigidbody rigidbody)
    {
        rigid = rigidbody;
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
    private void FixedUpdate()
    {
        StopMove();
        LeftMove();
        RightMove();
        JumpAndFall();
    }

    void StopMove()
    {
        if ((InputManager.Instance.IsLeftMove && InputManager.Instance.IsRightMove) || (!InputManager.Instance.IsLeftMove && !InputManager.Instance.IsRightMove))
        {
            rigid.velocity = new Vector3(0, rigid.velocity.y, rigid.velocity.z);
        }
    }
    void RightMove()
    {
        if (InputManager.Instance.IsRightMove)
        {
            rigid.velocity = new Vector3(moveSpeed, rigid.velocity.y, rigid.velocity.z);
        }
    }
    void LeftMove()
    {
        if (InputManager.Instance.IsLeftMove)
        {
            rigid.velocity = new Vector3(-moveSpeed, rigid.velocity.y, rigid.velocity.z);
        }
    }
    void JumpAndFall()
    {
        // Á¡ÇÁ
        if(InputManager.Instance.IsJump && isGrounded)
        {
            rigid.velocity += Vector3.up * jumpForce;
        }

        // ³«ÇÏ
        if (rigid.velocity.y < 0)
        {
            rigid.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigid.velocity.y > 0 && !InputManager.Instance.IsJump)
        {
            rigid.velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}