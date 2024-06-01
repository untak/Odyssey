using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("ÀÌµ¿")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Á¡ÇÁ")]
    [SerializeField] float jumpForce = 10f;
    bool isGrounded = true;

    [Header("³«ÇÏ")]
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    [SerializeField] float raycastDistance = 1.1f;

    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
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
            player.rigidbody.velocity = new Vector3(0, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void RightMove()
    {
        if (InputManager.Instance.IsRightMove)
        {
            player.rigidbody.velocity = new Vector3(moveSpeed, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void LeftMove()
    {
        if (InputManager.Instance.IsLeftMove)
        {
            player.rigidbody.velocity = new Vector3(-moveSpeed, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void JumpAndFall()
    {
        // Á¡ÇÁ
        if (InputManager.Instance.IsJump && isGrounded)
        {
            player.rigidbody.velocity += Vector3.up * jumpForce;
        }

        // ³«ÇÏ
        if (player.rigidbody.velocity.y < 0)
        {
            player.rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (player.rigidbody.velocity.y > 0 && !InputManager.Instance.IsJump)
        {
            player.rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}