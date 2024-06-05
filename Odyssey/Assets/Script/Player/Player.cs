using UnityEngine;

public class Player : Entity
{
    public PlayerMovement movement;
    public playerStats stats;

    private void Awake()
    {
        stats = GetComponent<playerStats>();
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
