using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMinion_PatrolState : State
{
    [SerializeField] float scanRadius = 0;
    public override void Enter()
    {
    }

    public override State Execute()
    {
        if (Physics.OverlapSphere(transform.position, scanRadius, (int)Define.LayerMask.PLAYER) != null)
        {
            return nextState;
        }
        else
        {
            return this;
        }
    }
}
