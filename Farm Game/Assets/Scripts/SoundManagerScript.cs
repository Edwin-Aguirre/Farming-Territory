using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    //Written by Edwin Aguirre

    private static AudioClip plantSound;
    private static AudioClip collectSound;
    private static AudioClip moveSound;
    private static AudioClip buyPlotSound;
    private static AudioClip plantAnimationEndSound;
    private static AudioClip notEnoughMoney; 

    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        plantSound = Resources.Load<AudioClip>("footstep_grass_002");
        collectSound = Resources.Load<AudioClip>("footstep_grass_004");
        moveSound = Resources.Load<AudioClip>("bong_001");
        buyPlotSound = Resources.Load<AudioClip>("footstep_grass_000");
        plantAnimationEndSound = Resources.Load<AudioClip>("select_006");
        notEnoughMoney = Resources.Load<AudioClip>("error_006");

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
            case "footstep_grass_000":
                audioSrc.PlayOneShot(buyPlotSound);
                break;
            case "select_006":
                audioSrc.PlayOneShot(plantAnimationEndSound);
                break;
            case "error_006":
                audioSrc.PlayOneShot(notEnoughMoney);
                break;
        }
    }
}
