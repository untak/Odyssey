using UnityEngine;

public class FireMinion : Enemy
{
    private void Awake()
    {
        sound = GetComponent<EnemySoundController>();

        RigidbodyInit();
        sound = GetComponent<EnemySoundController>();
        stats = GetComponent<FireMinion_Stats>();
    }

    private void Update()
    {
        StateTick();
    }
}
