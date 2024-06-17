using UnityEngine;

public class EnemyStats : EntityStats
{
    protected Enemy enemy;

    private void Awake()
    {
        enemy = gameObject.GetComponent<Enemy>();
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
