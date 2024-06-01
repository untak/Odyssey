using UnityEngine;

public class FireMinion : Enemy
{
    private void Awake()
    {
        RigidbodyInit();
        stats = GetComponent<FireMinion_Stats>();
    }

    private void Update()
    {
        StateTick();
    }
}
