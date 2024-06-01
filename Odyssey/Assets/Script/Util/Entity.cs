using UnityEngine;

public class Entity : MonoBehaviour
{
    [HideInInspector] public new Rigidbody rigidbody;

    protected virtual void ColliderInit()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), GetComponentsInChildren<Collider>()[1]);
    }
    protected virtual void RigidbodyInit()
    {
        rigidbody = GetComponent<Rigidbody>();

        // 컴포넌트가 없으면 추가
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }

        // 리지드바디 컴포넌트 초기화
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ |
                         RigidbodyConstraints.FreezeRotationZ |
                         RigidbodyConstraints.FreezeRotationX;
    }
}
