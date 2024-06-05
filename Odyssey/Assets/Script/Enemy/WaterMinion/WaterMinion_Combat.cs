public class WaterMinion_Combat : State
{
    WaterMinion_Stats stats;
    public override void Enter()
    {
        enemy.rigidbody.useGravity = true;
        stats = GetComponentInParent<WaterMinion_Stats>();
    }
    public override State Execute()
    {
        if (stats.isPlayerCrash)
        {
            Destroy(enemy.gameObject);
        }

        return this;
    }
}
