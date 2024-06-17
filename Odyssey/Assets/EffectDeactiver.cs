using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeactiver : MonoBehaviour
{
    [SerializeField] float deactiveTime;
    [SerializeField] bool isDestroy;
    float deactiveTimeDelta;
    private void Update()
    {
        deactiveTimeDelta += Time.deltaTime;
        if(deactiveTimeDelta > deactiveTime)
        {
            if (isDestroy)
            { 
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        deactiveTimeDelta = 0;
    }
}
