using UnityEngine;

public class playerStats : EntityStats
{
    [Header("무적 시간")]
    [SerializeField] float immuneTime; // 무적 시간 설정
    float immuneTimeDelta; // 남은 무적 시간을 추적하는 변수

    Player player;

    private void Awake()
    {
        player = gameObject.GetComponent<Player>(); // Player 컴포넌트 가져오기
    }
    private void Start()
    {
        if (GameScene.Instance.canAddHp)
        {
            hp = 5;
        }
        else
        {
            hp = 3;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
        // 매 프레임마다 남은 무적 시간을 감소시킴
        if (immuneTimeDelta > 0)
        {
            immuneTimeDelta -= Time.deltaTime;
        }
    }

    public override void TakeDamage(int damage)
    {
        if (immuneTimeDelta > 0)
        {
            return;  // 플레이어가 아직 무적 상태이면 메서드 종료
        }

        base.TakeDamage(damage); // 기본 데미지 처리 로직 실행
        FindObjectOfType<Hp_UI>().SetHp_UI(damage);
        immuneTimeDelta = immuneTime;  // 무적 시간 초기화
        player.sound.PlayHitSound();
    }
    protected override void Dead()
    {
        base.Dead(); // 기본 죽음 처리 로직 실행
        player.sound.PlayDeadSound();
    }
}