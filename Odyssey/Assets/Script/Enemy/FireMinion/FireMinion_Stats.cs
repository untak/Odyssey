using UnityEngine;

public class FireMinion_Stats : EnemyStats
{
    protected override void Dead()
    {
        enemy.sound.PlayDeadSound();
        base.Dead();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == (int)Define.LayerMask.PLAYER)
        {
            collision.gameObject.GetComponent<Player>().stats.TakeDamage(damage);
        }
    }
}
