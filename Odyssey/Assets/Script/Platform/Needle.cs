using UnityEngine;

public class Needle : MonoBehaviour
{
    [SerializeField] int damage = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == (int)Define.LayerMask.PLAYER)
        {
            collision.gameObject.GetComponent<Player>().stats.TakeDamage(damage);
        }
    }
}