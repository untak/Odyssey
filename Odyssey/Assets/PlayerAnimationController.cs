using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    string currentstateName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string stateName)
    {
        if(currentstateName == stateName)
        {
            return;
        }
        else
        {
            animator.StopPlayback();
            animator.CrossFade(stateName, 0.2f);
            currentstateName = stateName;
        }
    }
}
