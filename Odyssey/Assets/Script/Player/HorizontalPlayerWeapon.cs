using UnityEngine;

public class HorizontalPlayerWeapon : MonoBehaviour
{
    [SerializeField] Player player;
    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.layer == (int)Define.LayerMask.ENEMY)
            {
                other.GetComponent<EnemyStats>().TakeDamage(player.stats.GetDamage());
            }
        }

    }
}
