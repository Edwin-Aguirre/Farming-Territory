using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimations : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script is mainly used to change the tag of the animation at the end
    //so that you can't replace the plant while mid animation

    private Animator anim;

    [SerializeField]
    private GameObject moneyIndicator;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAnimation()
    {
        //anim.Play("BeetAnim");
    }

    void StopAnimation()
    {
        anim.StopPlayback();
        gameObject.tag = "Collect";
        moneyIndicator.SetActive(true);
    }
}
