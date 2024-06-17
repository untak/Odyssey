using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePhillar : MonoBehaviour
{
    [SerializeField] float deactiveTime;
    float deactiveTimeDelta;
    private void Update()
    {
        deactiveTimeDelta += Time.deltaTime;
        if(deactiveTimeDelta > deactiveTime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        deactiveTimeDelta = 0;
    }
}
