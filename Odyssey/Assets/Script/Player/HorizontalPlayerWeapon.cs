using System.Collections;
using System.Collections.Generic;
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
        if(other.gameObject.layer == (int)Define.LayerMask.ENEMY)
        {
            if(GetComponent<EnemyStats>() != null)
            {
                other.GetComponent<EnemyStats>().TakeDamage(player.stats.GetDamage());
            }
        }
    }
}
