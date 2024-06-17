using UnityEngine;

public class Stage1 : MonoBehaviour, StageGimmick
{
    [Header("쿨타임")]
    [SerializeField] float coolDown = 9f;
    float coolDownDelta = 0f;

    [Header("경고 시간")]
    [SerializeField] float warningTime = 1f;
    [SerializeField] float scalingSpeed;
    [Header("경고 오브젝트")]
    [SerializeField] GameObject warningObject;
    [SerializeField] float maxScale;

    [Header("대기 시간")]
    [SerializeField] float waitingTime = 1f;

    [Header("유지 시간")]
    [SerializeField] float holdingTime = 2f;
    [SerializeField] GameObject fireWall;

    float phaseTimeDelta = 0;

    Define.GimmickPhase_Stage1 phase = Define.GimmickPhase_Stage1.WARNING;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        warningObject.SetActive(false);
    }

    void Update()
    {
        coolDownDelta += Time.deltaTime;

        if(coolDownDelta >= coolDown)
        {
            Excute();
        }
    }

    public void Excute()
    {
        phaseTimeDelta += Time.deltaTime;
        Debug.Log(phaseTimeDelta);

        // 경고 페이즈
        if (phase == Define.GimmickPhase_Stage1.WARNING)
        {
            if(phaseTimeDelta < warningTime)
            {
                // 경고 오브젝트 활성화
                warningObject.SetActive(true);
                // 경고 오브젝트 플레이어 추격
                warningObject.transform.position = player.transform.position;
                // 경고 오브젝트 크기 증가
                float newScaleX = Mathf.Lerp(warningObject.transform.localScale.x, maxScale, scalingSpeed * Time.deltaTime);
                float newScaleZ = Mathf.Lerp(warningObject.transform.localScale.z, maxScale, scalingSpeed * Time.deltaTime);
                warningObject.transform.localScale = new Vector3(newScaleX, 50, newScaleZ);
            }
            else if(phaseTimeDelta >= warningTime) 
            {
                // 페이즈 초기화
                phaseTimeDelta = 0;
                phase = Define.GimmickPhase_Stage1.WAITING;
            }
        }
        // 대기 페이즈
        else if(phase == Define.GimmickPhase_Stage1.WAITING)
        {
            if(phaseTimeDelta < waitingTime)
            {

            }
            else if(phaseTimeDelta >= waitingTime)
            {
                // 페이즈 초기화
                phaseTimeDelta = 0;
                warningObject.SetActive(false);
                phase = Define.GimmickPhase_Stage1.LAUNCH;
            }
        }
        // 발동 페이즈
        else if(phase == Define.GimmickPhase_Stage1.LAUNCH)
        {
            // 초기화
            phase = Define.GimmickPhase_Stage1.WARNING;
            fireWall.SetActive(true);
            warningObject.transform.localScale = Vector3.zero;
            phaseTimeDelta = 0;
            coolDownDelta = 0;
        }
    }
}
