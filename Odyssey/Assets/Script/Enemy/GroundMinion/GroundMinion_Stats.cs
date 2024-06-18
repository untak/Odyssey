using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMinion_stats : EnemyStats
{
    public override void Dead()
    {
        SoundManager.Instance.PlayDeadSound();
        base.Dead();
    }
}
