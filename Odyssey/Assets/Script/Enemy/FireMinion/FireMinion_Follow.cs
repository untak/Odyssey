using UnityEngine;

public class FireMinion_Follow : State
{
    [Header("이동 속도")]
    [SerializeField] float followSpeed;
    [Header("폭발 범위")]
    [SerializeField] float explosionRadius;
    [Header("폭발 시간")]
    [SerializeField] float explosionTime;
    float explosionTimeDelta = 0f;
    [Header("폭발 데미지")]
    [SerializeField] int explosionDamage;
    [Header("색상 변경 시간")]
    [SerializeField] float interval = 1.0f;
    [Header("변경 색상")]
    [SerializeField] Color changeColor;
    [SerializeField] GameObject bombEffect;

    Player player = null;
    Renderer[] objectRenderer;
    Color[] originalColor;
    bool isColorChange = false;
    float timer = 0;

    public override void Enter()
    {
        // 플레이어 저장
        player = FindObjectOfType<Player>();
        // 객체의 Renderer를 가져와 초기 색상을 저장
        objectRenderer = enemy.GetComponentsInChildren<Renderer>();
        originalColor = new Color[objectRenderer.Length]; // 초기화 추가
        for (int i = 0; i < objectRenderer.Length; i++)
        {
            originalColor[i] = objectRenderer[i].material.color;
        }
    }

    public override State Execute()
    {
        FollowPlayer(); // 플레이어 추격

        // 범위 안에 플레이어가 있을 경우
        if (CheckPlayerInSphere())
        {
            ChangeColor();
            explosionTimeDelta += Time.deltaTime;
        }
        else
        {
            OriginColor(true);
            explosionTimeDelta = 0;
        }

        // 폭발
        if (explosionTimeDelta > explosionTime)
        {
            Explose();
        }

        return this;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    bool CheckPlayerInSphere()
    {
        // 원을 생성하고 중심을 설정
        Collider[] colliders = Physics.OverlapSphere(enemy.transform.position, explosionRadius);

        // 플레이어가 원 안에 있는지 확인
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.layer == (int)Define.LayerMask.PLAYER)
            {
                return true;
            }
        }
        return false;
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(player.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, newPosition, followSpeed * Time.deltaTime);
            if (player.transform.position.x > transform.position.x)
            {
                enemy.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                enemy.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
    }

    void Explose()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            // Entity 컴포넌트를 가지고 있는지 확인
            EntityStats stats = hitCollider.GetComponent<EntityStats>();
            if (stats != null)
            {
                // TakeDamage 함수 실행
                stats.TakeDamage(explosionDamage);
            }
        }
        SoundManager.Instance.PlayFireMinionExplosion();
        Instantiate(bombEffect, enemy.transform.position, enemy.transform.rotation);
        enemy.stats.Dead();
    }

    void ChangeColor()
    {
        timer += Time.deltaTime; // 프레임 시간 누적

        if (timer >= interval)
        {
            // interval 시간만큼 지났으면 색상 변경
            if (isColorChange)
            {
                OriginColor(true);
            }
            else
            {
                OriginColor(false);
            }

            isColorChange = !isColorChange; // 색상 변경 상태 반전
            timer = 0f; // 타이머 초기화
        }
    }

    void OriginColor(bool origin)
    {
        if (origin)
        {
            for (int i = 0; i < objectRenderer.Length; i++)
            {
                objectRenderer[i].material.color = originalColor[i];
            }
        }
        else
        {
            for (int i = 0; i < objectRenderer.Length; i++)
            {
                objectRenderer[i].material.color = changeColor; // 수정된 색상 변수 사용
            }
        }
    }
}