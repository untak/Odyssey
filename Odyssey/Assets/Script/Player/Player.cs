using UnityEngine;

public class Player : Entity
{
    [HideInInspector] public new CapsuleCollider collider;

    [HideInInspector] public PlayerMovement movement;
    [HideInInspector] public playerStats stats;
    [HideInInspector] public PlayerAnimationController anim;
    [HideInInspector] public PlayerSoundController sound;

    private void Awake()
    {
        sound = GetComponent<PlayerSoundController>();
        collider = GetComponent<CapsuleCollider>();
        anim = GetComponent<PlayerAnimationController>();
        stats = GetComponent<playerStats>();
        movement = GetComponent<PlayerMovement>();

        RigidbodyInit();
    }

    private void Start()
    {
        if(GetComponent<PlayerMovement>() == null)
        {
            movement = gameObject.AddComponent<PlayerMovement>();
        }
    }
}
