using UnityEngine;

public class GroundMinion : Enemy
{
    private void Awake()
    {
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
