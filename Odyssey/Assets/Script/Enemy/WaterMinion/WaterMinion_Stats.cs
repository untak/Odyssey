using UnityEngine;

public class WaterMinion_Stats : EntityStats
{
    public bool isGrounded = false;
    public bool isPlayerCrash = false;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision != null) 
        { 
            if(collision.gameObject.layer == (int)Define.LayerMask.GROUND)
            {
                enemy.rigidbody.velocity = Vector3.zero;
                isGrounded = true;
            }
            else if(collision.gameObject.layer == (int)Define.LayerMask.PLAYER)
            {
                isPlayerCrash = true;
            }
        }
    }
    public override void TakeDamage()
    {
    }
}
