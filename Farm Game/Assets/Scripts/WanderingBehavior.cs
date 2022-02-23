using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WanderingBehavior : MonoBehaviour
{
    
    public float movespeed = 2f;
    public float waitTime = 0f;
    public float movingTimeLimit = 0f;
    private Rigidbody body;
    private Vector3 destination;
    private Vector3 cPosition;    //Current position
    private float ranx;
    private float ranz;
    bool isMoving = false;
    

    // Start is called before the first frame update
    void Start()
    {
        cPosition = transform.position;
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (cPosition == destination)
        {
            Debug.Log("Waiting");
            StartCoroutine(Wait());
            isMoving = false;
            
        }

        else
        {
            Debug.Log("New destination");
            StartCoroutine(Wait());
            moveCharacter(destination);
        }

    }

    
    private void moveCharacter(Vector3 direction)
    {
        transform.LookAt(direction);
        transform.position = Vector3.MoveTowards(transform.position, direction, 1);
    }

    IEnumerator Wait()
    {
        if (isMoving == true)
        {
            yield return new WaitForSeconds(movingTimeLimit);
        }

        else
        {
            ranx = Random.Range(3, 4);
            ranz = Random.Range(-3, 3);
            destination = new Vector3(ranx, 0, ranz);
            
            isMoving = true;
            yield return new WaitForSeconds(waitTime);
        }

        

    }
}
