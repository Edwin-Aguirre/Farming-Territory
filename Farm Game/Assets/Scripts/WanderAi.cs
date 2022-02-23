using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WanderAi : MonoBehaviour
{

    public float movespeed = 2f;
    public float movingTimeLimit = 0f;
    private float waitTime;
    private Rigidbody body;
    private Vector3 destination;
    private Vector3 cPosition;    //Current position
    private float ranx;
    private float ranz;
    bool isMoving = false;
    bool startMove = false;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = movingTimeLimit;
        cPosition = transform.position;
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        StartCoroutine(Move());

    }


    private void moveCharacter(Vector3 direction)
    {
        transform.LookAt(direction);
        transform.position = Vector3.MoveTowards(transform.position, direction, movespeed * Time.deltaTime);
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
            ranx = Random.Range(3, 7);
            ranz = Random.Range(-3, 3);
            destination = new Vector3(ranx, 0, ranz);

            isMoving = true;
            startMove = true;
            
        }



    }
}
