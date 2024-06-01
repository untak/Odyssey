public class WaterMinion_Wait : State
{
    public override void Enter()
    {
        enemy.rigidbody.useGravity = false;
    }
    public override State Execute()
    {
        return this;
    }
}
