using UnityEngine;

public class Enemy : Entity
{
    [Header("현재 상태")]
    [SerializeField] protected State currentState;
    [Header("스탯")]
    [SerializeField] protected EntityStats stats;

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
}
