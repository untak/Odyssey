using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    protected int hp;
    protected Enemy enemy;

    private void Awake()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }
    public abstract void TakeDamage();
}
