using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int damage;
    [SerializeField] GameObject deadEffect;
    public int GetDamage()
    {
        return damage;
    }
    public void SetHp(int value)
    {
        hp = value;
    }
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }
    public virtual void Dead()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
