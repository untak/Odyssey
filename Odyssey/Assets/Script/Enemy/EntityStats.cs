using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int damage;

    public int GetDamage()
    {
        return damage;
    }
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }
    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
}
