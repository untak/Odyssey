public class WaterMinion_Launch : State
{
    WaterMinion_Stats stats;
    public override void Enter()
    {
        enemy.rigidbody.useGravity = true;
        stats = GetComponentInParent<WaterMinion_Stats>();
    }
    public override State Execute()
    {
        if(stats.isPlayerCrash)
        {
            Destroy(enemy.gameObject);
        }
        else if(stats.isGrounded)
        {
            return nextState;
        }

        return this;
    }
}
