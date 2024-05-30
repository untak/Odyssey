using UnityEngine;

public class WaitState : State
{
    [Header("대기 시간")]
    [SerializeField] float waitTime = 0;
    [SerializeField] float waitTimeDelta = 0f;
    public override void Enter()
    {
        waitTimeDelta = 0f;
    }
    public override State Execute()
    {
        waitTimeDelta += Time.deltaTime;

        if(waitTimeDelta > waitTime)
        {
            return nextState;
        }
        else
        {
            return this;
        }
    }
}
