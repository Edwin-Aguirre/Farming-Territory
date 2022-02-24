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
        waitTime = movingTimeLimit;
        cPosition = transform.position;
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(Move());
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


    private void moveCharacter(Vector3 direction)
    {
        //transform.LookAt(direction);
        // this.transform.parent.LookAt(direction, Vector3.up);
        //transform.position = Vector3.MoveTowards(transform.position, direction, movespeed * Time.deltaTime);
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
