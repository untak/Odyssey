using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.GetComponent<Player>() != null)
            {
                other.GetComponent<Player>().stats.TakeDamage(999);
            }
        }
    }
}
