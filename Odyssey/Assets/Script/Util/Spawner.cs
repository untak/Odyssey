using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("발사 힘")]
    [SerializeField] float launchForce = 0;

    [Header("소환 오브젝트")]
    [SerializeField] GameObject waterMinion;

    [Header("스폰 시간")]
    [SerializeField] float spawnTime = 2f;

    [Header("발사 시간")]
    [SerializeField] float waitingTime = 1f;

    BoxCollider boxCollider;
    Bounds bounds;
    GameObject go;

    private float timer = 0f;
    private bool hasSpawned = false;

    private void Awake()
    {
        BoxColliderInit();
    }

    private void Update()
    {
        if(waterMinion != null)
        {
            timer += Time.deltaTime;

            if (!hasSpawned && timer >= spawnTime)
            {
                go = Instantiate(waterMinion, GetRandomPositionInBounds(), Quaternion.identity);
                hasSpawned = true;
                timer = 0f; // 타이머를 초기화하여 다음 단계로 넘어감
            }
            else if (hasSpawned && timer >= waitingTime)
            {
                go.GetComponent<WaterMinion>().ChangeState(go.GetComponent<WaterMinion>().launchState);
                go.GetComponent<Rigidbody>().AddForce(Vector3.right * launchForce, ForceMode.Impulse);
                hasSpawned = false;
                timer = 0f; // 타이머를 초기화하여 다음 단계로 넘어감
            }
        }
    }

    Vector3 GetRandomPositionInBounds()
    {
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector3(transform.position.x, y, transform.position.z);
    }

    void BoxColliderInit()
    {
        boxCollider = GetComponent<BoxCollider>();

        if (boxCollider == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        boxCollider.excludeLayers = ~0;
        bounds = boxCollider.bounds; // BoxCollider의 경계 정보를 가져옴
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.layer == (int)Define.LayerMask.PLAYER)
            {
                collision.gameObject.GetComponent<playerStats>().TakeDamage(999);
            }
        }
    }
}