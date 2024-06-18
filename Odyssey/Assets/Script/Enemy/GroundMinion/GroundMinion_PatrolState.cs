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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, scanRadius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.layer == (int)Define.LayerMask.PLAYER)
            {
                return nextState;
            }
            i++;
        }
        return this;
    }
}
