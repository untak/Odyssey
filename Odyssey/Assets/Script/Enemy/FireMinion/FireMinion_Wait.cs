using UnityEngine;

public class FireMinion_Wait : State
{
    [Header("인식 범위(반지름)")]
    [SerializeField] float radius = 5f;
    public override State Execute()
    {
        if (CheckPlayerInSphere())
        {
            return nextState;
        }
        else
        {
            return this;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    bool CheckPlayerInSphere()
    {
        // 원을 생성하고 중심을 설정
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

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
}
