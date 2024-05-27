using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement playermovement;

    private void Awake()
    {
        RigidbodyInit();
    }

    private void Start()
    {
        if(GetComponent<PlayerMovement>() == null)
        {
            playermovement = gameObject.AddComponent<PlayerMovement>();
        }
    }

    void RigidbodyInit()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

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
