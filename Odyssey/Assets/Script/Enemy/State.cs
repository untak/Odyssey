using UnityEngine;

public abstract class State : MonoBehaviour
{
    [Header("다음 상태")]
    [SerializeField] protected State nextState;

    protected Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    // 상태가 시작될 때 한 번 실행되는 함수
    public virtual void Enter() { }

    // 상태가 매 프레임마다 실행되는 함수
    public abstract State Execute();

    // 상태가 종료될 때 한 번 실행되는 함수
    public virtual void Exit() { }
}
