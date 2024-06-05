using UnityEngine;

public class EnemyStats : EntityStats
{
    protected Enemy enemy;

    private void Awake()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == (int)Define.LayerMask.PLAYER)
        {
            collision.gameObject.GetComponent<Player>().stats.TakeDamage(damage);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    protected override void Dead()
    {
        base.Dead();
    }
}
