using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    //Written by Edwin Aguirre

    private static AudioClip plantSound;
    private static AudioClip collectSound;
    private static AudioClip moveSound;
    private static AudioClip testSound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        plantSound = Resources.Load<AudioClip>("footstep_grass_002");
        collectSound = Resources.Load<AudioClip>("footstep_grass_004");
        moveSound = Resources.Load<AudioClip>("bong_001");
        testSound = Resources.Load<AudioClip>("error_006");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "footstep_grass_002":
                audioSrc.PlayOneShot(plantSound);
                break;
            case "footstep_grass_004":
                audioSrc.PlayOneShot(collectSound);
                break;
            case "bong_001":
                audioSrc.PlayOneShot(moveSound);
                break;
            case "error_006":
                audioSrc.PlayOneShot(testSound);
                break;
        }
    }
}
