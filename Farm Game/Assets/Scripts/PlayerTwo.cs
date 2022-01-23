using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTwoMovement();
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    private void PlayerTwoMovement()
    {
        if(Input.GetKey(KeyCode.UpArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.forward));
        }
        if(Input.GetKey(KeyCode.LeftArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(new Vector3(-0.9f,0,0)));
        }
        if(Input.GetKey(KeyCode.DownArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.back));
        }
        if(Input.GetKey(KeyCode.RightArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(new Vector3(0.9f,0,0)));
        }
    }
}
