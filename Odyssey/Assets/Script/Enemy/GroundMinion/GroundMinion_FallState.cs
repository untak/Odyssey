using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMinion_FallState : State
{
    public override void Enter()
    {
        enemy.rigidbody.isKinematic = false;
        enemy.sound.PlayEarthMinionFallSound();
    }

    public override State Execute()
    {
        return this;
    }
}
