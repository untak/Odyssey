using UnityEngine;

public class FireMinion_Stats : EnemyStats
{
    public override void Dead()
    {
        SoundManager.Instance.PlayDeadSound();
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
