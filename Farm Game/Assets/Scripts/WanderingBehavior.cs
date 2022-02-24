using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WanderingBehavior : MonoBehaviour
{
    public float speed = 2f;
    public float xPos;
    public float zPos;
    public Vector3 desiredPos;
    public float timer = 1f;
    public float timerSpeed;
    public float timeToMove;

    private void Start() 
    {
        xPos = Random.Range(4.5f,8.1f);
        zPos = Random.Range(2.7f,-2.7f);
        desiredPos = new Vector3(xPos, 0.1f, zPos);
    }

    private void Update() 
    {
        timer += Time.deltaTime * timerSpeed;
        if(timer >= timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
            if(Vector3.Distance(transform.position, desiredPos) <= 0.01f)
            {
                xPos = Random.Range(4.5f,8.1f);
                zPos = Random.Range(2.7f,-2.7f);
                desiredPos = new Vector3(xPos, 0.1f, zPos);
                timer = 0.0f;
            }
        }
    }
    
}
