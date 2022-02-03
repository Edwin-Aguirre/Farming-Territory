using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    //This script lets the player hover their mouse above objects and gives a description of them
    
    [TextArea]
    [SerializeField]
    private string message;

    private void OnMouseEnter() 
    {
        TooltipManager.instance.ShowToolTip(message);
    }

    private void OnMouseExit() 
    {
        TooltipManager.instance.HideToolTip();
    }
}
