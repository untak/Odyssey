using UnityEngine;

public class WindMinion_Rush : State
{
    [Header("이동 속도")]
    [SerializeField] float moveSpeed = 5f;

    Vector3 targetPos;

    public override void Enter()
    {
        targetPos = (FindObjectOfType<Player>().transform.position - transform.position).normalized;
        enemy.rigidbody.velocity = targetPos * moveSpeed;
        enemy.sound.PlayWindMinionDash();
        enemy.transform.LookAt(targetPos);
    }
    public override State Execute()
    {
        return this;
    }
}
