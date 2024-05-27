using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] BoxCollider hitBox;
    [SerializeField] float scanRadius;

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        RigidbodyInit();
        hitBox.isTrigger = true;
    }
    private void Update()
    {
        ScanPlayer();
    }
    void ScanPlayer()
    {
        if (Physics.OverlapSphere(transform.position, scanRadius, (int)Define.LayerMask.PLAYER) != null)
        {
            rigid.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
        }
    }

    void RigidbodyInit()
    {
        // 컴포넌트가 없으면 추가
        if (rigid == null)
        {
            rigid = gameObject.AddComponent<Rigidbody>();
        }

        // 리지드바디 컴포넌트 초기화
        rigid.isKinematic = true;
        rigid.constraints = RigidbodyConstraints.FreezeRotationZ |
                            RigidbodyConstraints.FreezeRotationX |
                            RigidbodyConstraints.FreezeRotationY |
                            RigidbodyConstraints.FreezePositionZ;
    }
}