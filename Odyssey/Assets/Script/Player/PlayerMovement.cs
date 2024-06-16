using Unity.Burst.CompilerServices;
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
    GameObject groundObject;

    [Header("낙하")]
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    [SerializeField] float raycastStartPoint = 0;
    [SerializeField] float raycastDistance = 1.1f;

    [Header("공격")]
    [SerializeField] float attackCooldown;
    float attackCooldownDelta = 0;
    [SerializeField] float attackDuration;
    float attackDurationDelta = 0;
    [SerializeField] int dashDamage = 0;
    [SerializeField] GameObject horizontalHitBox;
    [SerializeField] GameObject downHitBox;

    [Header("대쉬")]
    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing = false;
    float dashTime = 0;
    float dashCooldownDelta = 0;
    [SerializeField] int damageDuringDash = 10;

    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        attackCooldownDelta = attackCooldown;
    }

    private void Update()
    {
        #region 바닥 판정
        if (isGrounded)
            Debug.Log("asdf");
        RaycastHit hit;
        Vector3 startPoint = new Vector3(transform.position.x, transform.position.y + raycastStartPoint, transform.position.z);
        Debug.DrawRay(startPoint, Vector3.down * raycastDistance, Color.red);
        isGrounded = Physics.Raycast(startPoint, Vector3.down * raycastDistance, out hit, raycastDistance);
        if (isGrounded && player.rigidbody.velocity.y <= 0)
        {
            groundObject = hit.collider.gameObject;
            isJump = false;
            isDoubleJump = false;
        }
        #endregion

        #region 쿨타임
        attackCooldownDelta += Time.deltaTime;
        dashCooldownDelta += Time.deltaTime;

        attackDurationDelta += Time.deltaTime;
        if (attackDurationDelta > attackDuration)
        {
            horizontalHitBox.gameObject.SetActive(false);
            downHitBox.gameObject.SetActive(false);
        }
        #endregion

        if (!isDashing) // 대쉬 중이 아닐 때만 다른 동작 수행
        {
            Attack(); // 공격
            JumpAndFall(); // 점프 및 낙하
        }

        Dash(); // 대쉬
    }

    private void FixedUpdate()
    {
        if (!isDashing) // 대쉬 중이 아닐 때만 이동 수행
        {
            StopMove(); // 이동 멈춤
            LeftMove(); // 좌측 이동
            RightMove(); // 우측 이동
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDashing && other.gameObject.layer == (int)Define.LayerMask.ENEMY)
        {
            EnemyStats enemy = other.gameObject.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageDuringDash);
            }

            if (other.GetComponent<GroundMinion>() != null)
            {
                isDashing = false;
            }
        }
        else if (isDashing && other.gameObject.layer == (int)Define.LayerMask.GROUND)
        {
            if(other.gameObject != groundObject)
            {
                isDashing = false;
                player.rigidbody.useGravity = true;
                player.collider.isTrigger = false;
            }
        }
    }

    void StopMove()
    {
        if ((InputManager.Instance.IsLeftMove && InputManager.Instance.IsRightMove) || (!InputManager.Instance.IsLeftMove && !InputManager.Instance.IsRightMove))
        {
            if(!isJump)
            {
                player.anim.PlayAnimation("idle");
            }
            player.rigidbody.velocity = new Vector3(0, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void RightMove()
    {
        if (InputManager.Instance.IsRightMove)
        {
            if(!isJump)
            {
                player.anim.PlayAnimation("run");
            }
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            player.rigidbody.velocity = new Vector3(moveSpeed, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void LeftMove()
    {
        if (InputManager.Instance.IsLeftMove)
        {
            if (!isJump)
            {
                player.anim.PlayAnimation("run");
            }
            player.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            player.rigidbody.velocity = new Vector3(-moveSpeed, player.rigidbody.velocity.y, player.rigidbody.velocity.z);
        }
    }
    void JumpAndFall()
    {
        if (InputManager.Instance.IsJump)
        {
            if (isGrounded)
            {
                player.anim.PlayAnimation("jump");
                player.rigidbody.velocity += Vector3.up * jumpForce;
                isJump = true;
            }
            else if (isJump && !isDoubleJump && GameScene.Instance.canDoubleJump)
            {
                player.anim.PlayAnimation("jump");
                player.rigidbody.velocity += Vector3.up * jumpForce;
                isDoubleJump = true;
            }
        }

        if (player.rigidbody.velocity.y < 0)
        {
            player.rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            if(!isGrounded)
            {
                player.anim.PlayAnimation("fall");
            }
        }
        else if (player.rigidbody.velocity.y > 0 && !InputManager.Instance.IsJump)
        {
            player.rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            if(!isGrounded)
            {
                player.anim.PlayAnimation("fall");
            }
        }
    }
    void Attack()
    {
        if (InputManager.Instance.IsAttack)
        {
            if (attackCooldownDelta < attackCooldown)
                return;

            if (InputManager.Instance.IsDownMove && !isGrounded)
            {
                downHitBox.gameObject.SetActive(true);
            }
            else
            {
                horizontalHitBox.gameObject.SetActive(true);
            }

            attackCooldownDelta = 0;
            attackDurationDelta = 0;
        }
    }
    void Dash()
    {
        if (InputManager.Instance.IsDash && dashCooldownDelta >= dashCooldown && GameScene.Instance.canDash)
        {
            isDashing = true;
            dashTime = 0;
            dashCooldownDelta = 0;
            player.collider.isTrigger = true;
            player.rigidbody.useGravity = false;
        }

        if (isDashing)
        {
            dashTime += Time.deltaTime;

            if (dashTime < dashDuration)
            {
                Vector3 dashDirection = player.transform.forward;
                player.rigidbody.velocity = dashDirection * dashSpeed;
            }
            else
            {
                isDashing = false;
                player.rigidbody.useGravity = true;
                player.collider.isTrigger = false;
            }
        }
    }
}