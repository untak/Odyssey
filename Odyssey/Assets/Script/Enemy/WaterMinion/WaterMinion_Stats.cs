using UnityEngine;

public class WaterMinion_Stats : EnemyStats
{
    public bool isPlayerCrash = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.layer == (int)Define.LayerMask.GROUND)
            {
                enemy.rigidbody.velocity = Vector3.zero;
            }
            else if (collision.gameObject.layer == (int)Define.LayerMask.PLAYER)
            {
                isPlayerCrash = true;
                collision.gameObject.GetComponent<Player>().stats.TakeDamage(damage);
            }
        }
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Dead()
    {
        SoundManager.Instance.PlayDeadSound();
        base.Dead();
    }
}
