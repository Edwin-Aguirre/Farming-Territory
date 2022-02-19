using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script handles the Shop in the game.
    //Use Q and E to move indicator on a vegetable on the left, and it will let you buy them.

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private Vector3 moveUpUnits = new Vector3(0,0,0.9f);
    private Vector3 moveDownUnits = new Vector3(0,0,-0.9f);

    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private GameObject beetAnimation;

    [SerializeField]
    private GameObject cabbageAnimation;

    [SerializeField]
    private GameObject carrotAnimation;

    [SerializeField]
    private GameObject cornAnimation;

    [SerializeField]
    private GameObject redPepperAnimation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShopMovement();
        ShopRaycast();
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
    

    void ShopMovement()//Moving with wasd in a grid layout
    {
        if(Input.GetKey(KeyCode.E) && !isMoving)
        {
            StartCoroutine(MovePlayer(moveUpUnits));
        }
        if(Input.GetKey(KeyCode.Q) && !isMoving)
        {
            StartCoroutine(MovePlayer(moveDownUnits));
        }
    }

    void WallUpRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.forward);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallUp")
            {
                targetPos = origPos;
            }
            
        }
    }

    void WallDownRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.back);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallDown")
            {
                targetPos = origPos;
            }
            
        }
    }

    void ShopRaycast()
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "BuyBeet" && MoneyManager.instance.money >= MoneyManager.instance.beetCost)
            {
                PlantSpawner.instance.plantAnimation = beetAnimation;
            }
            if(hit.collider.tag == "BuyCabbage" && MoneyManager.instance.money >= MoneyManager.instance.cabbageCost)
            {
                PlantSpawner.instance.plantAnimation = cabbageAnimation;
            }
            if(hit.collider.tag == "BuyCarrot" && MoneyManager.instance.money >= MoneyManager.instance.carrotCost)
            {
                PlantSpawner.instance.plantAnimation = carrotAnimation;
            }
            if(hit.collider.tag == "BuyCorn" && MoneyManager.instance.money >= MoneyManager.instance.cornCost)
            {
                PlantSpawner.instance.plantAnimation = cornAnimation;
            }
            if(hit.collider.tag == "BuyRedPepper" && MoneyManager.instance.money >= MoneyManager.instance.redPepperCost)
            {
                PlantSpawner.instance.plantAnimation = redPepperAnimation;
            }
        }
    }
}
