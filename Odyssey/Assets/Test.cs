using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] public GameObject effect;

    private void Start()
    {
        Instantiate(effect, transform);
    }
}
