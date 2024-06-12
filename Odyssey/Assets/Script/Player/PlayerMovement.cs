using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동")]
    [SerializeField] float moveSpeed = 5f;

    [Header("점프")]
    [SerializeField] float jumpForce = 10f;
    bool isGrounded = true;
    bool isJump = false;
    bool isDoubleJump = false;

    [Header("낙하")]
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    [SerializeField] float raycastDistance = 1.1f;

    [Header("공격")]
    [SerializeField] float attackCooldown;
    float attackCooldownDelta = 0;
    [SerializeField] float attackDuration;
    float attackDurationDelta = 0;
    [SerializeField] GameObject horizontalHitBox;
    [SerializeField] GameObject downHitBox;

    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        attackCooldownDelta = attackCooldown;
    }
    private void Update()
    {
        #region 바닥 판정
        // 바닥 판정
        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, raycastDistance);
        if (isGrounded && player.rigidbody.velocity.y <= 0)
        {
            isJump = false;
            isDoubleJump = false;
        }
        #endregion

        #region 쿨타임
        // 공격 쿨타임
        attackCooldownDelta += Time.deltaTime;
        // 공격 비활성화
        attackDurationDelta += Time.deltaTime;
        if (attackDurationDelta > attackDuration)
        {
            horizontalHitBox.gameObject.SetActive(false);
            downHitBox.gameObject.SetActive(false);
        }
        #endregion

        Attack(); // 공격
        JumpAndFall(); // 점프 및 낙하
    }
    private void FixedUpdate()
    {
        StopMove(); // 이동 멈춤
        LeftMove(); // 좌측 이동
        RightMove(); // 우측 이동
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
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            player.rigidbody.velocity = new Vector3(moveSpeed, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void LeftMove()
    {
        if (InputManager.Instance.IsLeftMove)
        {
            player.transform.rotation = Quaternion.Euler(Vector3.zero);
            player.rigidbody.velocity = new Vector3(-moveSpeed, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void JumpAndFall()
    {
        // 점프
        if (InputManager.Instance.IsJump)
        {
            if (isGrounded)
            {
                player.rigidbody.velocity += Vector3.up * jumpForce;
                isJump = true;
            }
            else if (isJump && !isDoubleJump)
            {
                player.rigidbody.velocity += Vector3.up * jumpForce;
                isDoubleJump = true;
            }
        }

        // 낙하
        if (player.rigidbody.velocity.y < 0)
        {
            player.rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (player.rigidbody.velocity.y > 0 && !InputManager.Instance.IsJump)
        {
            player.rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void Attack()
    {
        if (InputManager.Instance.IsAttack)
        {
            // 쿨타임이면 return
            if (attackCooldownDelta < attackCooldown)
                return;

            // 공중이고 아래키를 누르고 있으면 하단 공격
            if (InputManager.Instance.IsDownMove && !isGrounded)
            {
                downHitBox.gameObject.SetActive(true);
            }
            // 횡공격
            else
            {
                horizontalHitBox.gameObject.SetActive(true);
            }

            attackCooldownDelta = 0;
            attackDurationDelta = 0;
        }
    }

}