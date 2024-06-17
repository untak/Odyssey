using UnityEngine;

public class WaterMinion : Enemy
{
    [Header("==========")]
    public State launchState;
    private void Awake()
    {
        sound = GetComponent<EnemySoundController>();

        RigidbodyInit();
        stats = GetComponent<WaterMinion_Stats>();
    }
    private void Start()
    {
    }

    private void Update()
    {
        StateTick();
    }

    protected override void RigidbodyInit()
    {
        base.RigidbodyInit();
        rigidbody.useGravity = false;
    }
}
