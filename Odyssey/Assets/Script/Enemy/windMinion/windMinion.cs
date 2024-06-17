using System.Collections;
using UnityEngine;

public class windMinion : Enemy
{
    private bool isVisible = false; // Minion이 보이는지 여부를 추적
    private bool canUpdate = false; // Update 함수가 실행 가능한지 여부를 추적
    [SerializeField] State initState;

    private void Awake()
    {
        sound = GetComponent<EnemySoundController>();

        RigidbodyInit();
        stats = GetComponent<WindMinion_Stats>();
    }
    void Update()
    {
        if (canUpdate)
        {
            StateTick();
        }
        else
        {
            CheckVisibility(); // Minion이 보이는지 확인
        }
    }
    protected override void StateTick()
    {
        base.StateTick();
    }
    void CheckVisibility()
    {
        if (IsVisible() && !isVisible)
        {
            StartCoroutine(StartUpdatingAfterDelay()); // 1초 후에 Update 함수가 실행되도록 코루틴 시작
        }
    }
    IEnumerator StartUpdatingAfterDelay()
    {
        yield return new WaitForSeconds(1); // 1초 대기
        ChangeState(initState); // Minion이 처음으로 보였을 때
        canUpdate = true; // 1초 후에 Update 함수 실행 가능
    }
    bool IsVisible()
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        // 뷰포트 내에 있는지 확인
        return viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1 && viewportPoint.z > 0;
    }
    protected override void RigidbodyInit()
    {
        base.RigidbodyInit();
        rigidbody.useGravity = false;
    }
}