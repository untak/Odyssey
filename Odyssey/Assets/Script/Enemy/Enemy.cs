using UnityEngine;

public class Enemy : Entity
{
    [Header("현재 상태")]
    [SerializeField] protected State currentState;
    [Header("스탯")]
    [SerializeField] public EntityStats stats;
    public EnemySoundController sound;

    public State getState()
    {
        return currentState;
    }
    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    protected virtual void StateTick()
    {
        if (currentState != null)
        {
            State nextState = currentState.Execute();
            if (nextState != currentState)
            {
                ChangeState(nextState);
            }
        }
    }
}
