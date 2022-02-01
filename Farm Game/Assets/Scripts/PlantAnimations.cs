using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimations : MonoBehaviour
{
    private Animator anim;

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
        gameObject.tag = "Plant";
    }
}
