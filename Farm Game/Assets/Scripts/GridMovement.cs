using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script allows the player to move in a grid layout
    //It also uses perfect movement so that the Selector or player can be directly above each plot

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private Vector3 moveRightUnits = new Vector3(0.9f,0,0);
    private Vector3 moveLefttUnits = new Vector3(-0.9f,0,0);
    private Vector3 moveUpUnits = new Vector3(0,0,0.9f);
    private Vector3 moveDownUnits = new Vector3(0,0,-0.9f);

    [SerializeField]
    private float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerOneMovement();
        WallRightRaycast();
        WallLeftRaycast();
        WallUpRaycast();
        WallDownRaycast();
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

    private void PlayerOneMovement()//Moving with wasd in a grid layout
    {
        if(Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(moveUpUnits));
        }
        if(Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(moveLefttUnits));
        }
        if(Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(moveDownUnits));
        }
        if(Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(moveRightUnits));
        }
    }

    public void WallRightRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.right);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallRight")
            {
                targetPos = origPos;
                SoundManagerScript.PlaySound("bong_001");
            }
            
        }
    }

    public void WallLeftRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.left);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallLeft")
            {
                targetPos = origPos;
                SoundManagerScript.PlaySound("bong_001");
            }
            
        }
    }

    public void WallUpRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.forward);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallUp")
            {
                targetPos = origPos;
                SoundManagerScript.PlaySound("bong_001");
            }
            
        }
    }

    public void WallDownRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.back);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallDown")
            {
                targetPos = origPos;
                SoundManagerScript.PlaySound("bong_001");
            }
            
        }
    }
}
