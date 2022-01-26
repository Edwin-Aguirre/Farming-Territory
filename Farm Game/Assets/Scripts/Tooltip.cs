using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
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
