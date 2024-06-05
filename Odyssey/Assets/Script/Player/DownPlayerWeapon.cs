using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlayerWeapon : MonoBehaviour
{
    [Header("Æ¨±â´Â Èû")]
    [SerializeField] float bounceForce = 1f;
    [Header("==========")]
    [SerializeField] Player player;
    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Define.LayerMask.ENEMY)
        {
            player.rigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            if(other.GetComponent<EnemyStats>() != null ) 
            { 
                other.GetComponent<EnemyStats>().TakeDamage(player.stats.GetDamage());
            }
        }
    }
}
