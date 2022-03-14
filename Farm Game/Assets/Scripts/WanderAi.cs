using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAi : MonoBehaviour
{
    //Written by Bryan Castaneda and edited by Edwin Aguirre
    [SerializeField]
    private float movespeed = 2f;
    [SerializeField]
    private float movingTimeLimit = 0f;
    private List<GameObject> crops = new List<GameObject>();
    private float prevCrop;
    private float counter;
    private Transform form;
    private Transform nearestCrop;
    private float waitTime;
    private Rigidbody body;
    private Vector3 destination;
    private Vector3 cPosition;    //Current position
    private float ranx;
    private float ranz;
    private bool isMoving = false;
    private bool startMove = false;
    

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        waitTime = movingTimeLimit;
        cPosition = transform.position;
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

        StartCoroutine(Move());

        if (FindCrops() != null)
        {
            destination = form.position;
            form = null;
        }
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * movespeed);
        if(Vector3.Distance(transform.position, destination) <= 0.01f)
        {
            ranx = Random.Range(0,10);
            ranz = Random.Range(-20,20);
            destination = new Vector3(ranx, 0.1f, ranz);
            isMoving = true;
            startMove = true;
        }
    }


    private void moveCharacter(Vector3 direction)//Did not work as expected
    {
        //transform.LookAt(direction);
        // this.transform.parent.LookAt(direction, Vector3.up);
        //transform.position = Vector3.MoveTowards(transform.position, direction, movespeed * Time.deltaTime);
    }

    private Transform FindCrops()
    {
        
        float nearestCrop = Mathf.Infinity;
        form = null;
        

        if (GameObject.FindGameObjectsWithTag("Crop").Length >= 1)
        {

            foreach (GameObject crop in GameObject.FindGameObjectsWithTag("Crop"))
            {
                crops.Add(crop);
            }

            foreach (GameObject crop in crops)
            {
                float distance;
                distance = Vector3.Distance(transform.position, crop.transform.position);

                if (distance == prevCrop)
                {
                    crops.Remove(crop);
                }
                else if (distance < nearestCrop)
                {
                    nearestCrop = distance;
                    prevCrop = nearestCrop;
                    form = crop.transform;
                }

                else
                {
                    form = null;
                }

            }

            crops.Clear();
            
            return form;
        }

        else
        {
            return null;
        }
        
    }

    IEnumerator Move()
    {
        if (startMove == true)
        {
            moveCharacter(destination);
            startMove = false;
            yield return null;
        }
        else if (isMoving == true)
        {
            waitTime -= Time.deltaTime;

            if (waitTime <= 0)
            {
                isMoving = false;
                waitTime = movingTimeLimit;
            }
            
        }
        else
        {
            ranx = Random.Range(0,10);
            ranz = Random.Range(-20,20);
            destination = new Vector3(ranx, 0, ranz);

            isMoving = true;
            startMove = true;
        }  
    }
}



