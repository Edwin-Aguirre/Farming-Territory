using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script allows the player to shoot a raycast under them to dectect an object
    //Whatever hits the raycast, will replace its material to look like it is highlighted

    [SerializeField]
    private Material highlightMaterial;
    [SerializeField]
    private Material defaultMaterial;
    
    private Transform _selection;

    [SerializeField]
    private LayerMask selectLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        SelectionRaycast();
    }

    void SelectionRaycast()//When the player is above a plot of land, it will get change materials to make it look like it was selected
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit, selectLayer))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if(selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
        }
    }
}
