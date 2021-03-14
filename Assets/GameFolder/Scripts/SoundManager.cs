using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static AudioClip fireSound;
    static AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        fireSound = Resources.Load<AudioClip>("FireHit");
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fireSound":
                audioSource.PlayOneShot(fireSound);
                break;
        }
    }
}
