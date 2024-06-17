using UnityEngine;

public class GroundMinion : Enemy
{
    [Header("히트 박스 위치")]
    [SerializeField] Vector3 boxSize = new Vector3(1, 1, 1);
    [SerializeField] Vector3 damagePos;

    private void Awake()
    {
        sound = GetComponent<EnemySoundController>();

        this.RigidbodyInit();
        stats = GetComponent<GroundMinion_stats>();
    }

    private void Update()
    {
        StateTick();
    }

    protected override void RigidbodyInit()
    {
        rigidbody = GetComponent<Rigidbody>();

        // 컴포넌트가 없으면 추가
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }

        // 리지드바디 컴포넌트 초기화
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ |
                         RigidbodyConstraints.FreezePositionX |
                         RigidbodyConstraints.FreezeRotationZ |
                         RigidbodyConstraints.FreezeRotationX;
        rigidbody.isKinematic = true;
        rigidbody.useGravity = true;
    }
}
