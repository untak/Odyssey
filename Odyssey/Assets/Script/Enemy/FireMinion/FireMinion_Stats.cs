using UnityEngine;

public class FireMinion_Stats : EnemyStats
{
    protected override void Dead()
    {
        enemy.sound.PlayDeadSound();
        base.Dead();
    }
}
