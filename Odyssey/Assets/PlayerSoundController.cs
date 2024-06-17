using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] AudioClip dash;
    [SerializeField] AudioClip doubleJump;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip dead;
    [SerializeField] AudioClip attack;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayDashSound()
    {
        audio.PlayOneShot(dash);
    }
    public void PlayDoubleJumpSound()
    {
        audio.PlayOneShot(doubleJump);
    }
    public void PlayHitSound()
    {
        audio.PlayOneShot(hit);
    }
    public void PlayDeadSound()
    {
        audio.PlayOneShot(dead);
    }
    public void PlayAttackSound()
    {
        audio.PlayOneShot(attack);
    }
}
