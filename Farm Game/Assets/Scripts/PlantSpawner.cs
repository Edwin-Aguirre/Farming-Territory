using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField]
    private Mesh emptyPlotMesh;

    //Temp
    [SerializeField]
    private GameObject plantAnimation;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MeshRaycast();
    }

    public void MeshRaycast()
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "Buy" && Input.GetKeyDown("space"))
            {
                hit.transform.gameObject.tag = "Plant";//When the player collects the plant, it changes its tag so you can plant seeds.
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<MeshFilter>();
                if(selectionRenderer != null)
                {
                    selectionRenderer.mesh = emptyPlotMesh;
                }
            }
            else if(hit.collider.tag == "Plant" && Input.GetKeyDown("space"))
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<MeshFilter>();
                if(selectionRenderer != null)
                {
                    //selectionRenderer.mesh = seedMesh;
                    Destroy(hit.transform.parent.gameObject);//temp
                    Instantiate(plantAnimation, hit.transform.position, transform.rotation);//tmep
                }
            }
            
        }
    }
}
