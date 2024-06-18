using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("@SoundManager");
                    _instance = singletonObject.AddComponent<SoundManager>();
                }
            }
            DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }

    protected new AudioSource audio;
    [SerializeField] AudioClip dead;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip earthMinion_Fall;
    [SerializeField] AudioClip fireMinion_Explosion;
    [SerializeField] AudioClip waterMinion_start;
    [SerializeField] AudioClip windMinionDash;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        if (dead == null)
        {
            Debug.Log("null");
        }
    }

    public void PlayDeadSound()
    {
        audio.PlayOneShot(dead);
    }
    public void PlayHitSound()
    {
        audio.PlayOneShot(hit);
    }
    public void PlayEarthMinionFallSound()
    {
        audio.PlayOneShot(earthMinion_Fall);
    }
    public void PlayFireMinionExplosion()
    {
        audio.PlayOneShot(fireMinion_Explosion);
    }
}
