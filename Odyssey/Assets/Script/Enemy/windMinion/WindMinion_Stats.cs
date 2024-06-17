using UnityEngine;

public class WindMinion_Stats : EnemyStats
{
    [Header("충돌 힘")]
    [SerializeField] float bounceForce = 10f;

    [Header("이동 시간")]
    [SerializeField] float bounceTime = 1f;

    [Header("==========")]
    [SerializeField] WindMinion_Wait waitState;

    float bounceTimeDelta = 0f;
    bool isBouncing = false;

    private void FixedUpdate()
    {
        if (isBouncing)
        {
            bounceTimeDelta += Time.deltaTime; // 경과 시간 업데이트

            if (bounceTimeDelta >= bounceTime)
            {
                // 일정 시간이 지나면 튕김을 멈추고 속도를 0으로 설정
                enemy.rigidbody.velocity = Vector3.zero;
                bounceTimeDelta = 0.0f; // 경과 시간 초기화
                enemy.ChangeState(waitState);
                isBouncing = false;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        // Damage logic here
    }
    public override void Dead()
    {
        enemy.sound.PlayDeadSound();
        base.Dead();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && !isBouncing)
        {
            // 현재 속도의 반대 방향으로 벡터 설정 및 크기 조정
            Vector3 currentVelocity = enemy.rigidbody.velocity;
            Vector3 reverseVelocity = -currentVelocity.normalized * bounceForce;

            // 반대 방향으로 속도 설정
            enemy.rigidbody.velocity = reverseVelocity;

            // 튕김 상태 활성화
            isBouncing = true;
        }

        if (collision.gameObject.layer == (int)Define.LayerMask.PLAYER)
        {
            collision.gameObject.GetComponent<Player>().stats.TakeDamage(damage);
        }
    }
}