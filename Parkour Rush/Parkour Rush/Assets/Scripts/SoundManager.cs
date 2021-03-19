using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip WalkingSound, SlidingSound, JumpingSound, DamageSound, PowerUpSound;
        static AudioSource playersounds;

    // Start is called before the first frame update
    void Start()
    {
        WalkingSound = Resources.Load<AudioClip>("Footstep");
        SlidingSound = Resources.Load<AudioClip>("Slide");
        JumpingSound = Resources.Load<AudioClip>("Jump");
        DamageSound = Resources.Load<AudioClip>("Damage");
        PowerUpSound = Resources.Load<AudioClip>("PowerUp");

        playersounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Footstep":
                playersounds.PlayOneShot(WalkingSound);
                break;
            case "Slide":
                playersounds.PlayOneShot(SlidingSound);
                break;
            case "Jump":
                playersounds.PlayOneShot(JumpingSound);
                break;
            case "Damage":
                playersounds.PlayOneShot(DamageSound);
                break;
            case "PowerUp":
                playersounds.PlayOneShot(PowerUpSound);
                break;
        }
    }
}
