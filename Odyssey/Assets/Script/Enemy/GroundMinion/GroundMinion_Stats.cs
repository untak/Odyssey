using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMinion_stats : EnemyStats
{
    public override void Dead()
    {
        enemy.sound.PlayDeadSound();
        base.Dead();
    }
}
