using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop2 : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script handles the player 2 Shop in the game.
    //Use [ and \ to move indicator on a vegetable on the left, and it will let you buy them.

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private Vector3 moveUpUnits = new Vector3(0,0,0.9f);
    private Vector3 moveDownUnits = new Vector3(0,0,-0.9f);

    [SerializeField]
    private float rayDistance;

    [SerializeField]
    public GameObject beetAnimation;

    [SerializeField]
    public GameObject cabbageAnimation;

    [SerializeField]
    public GameObject carrotAnimation;

    [SerializeField]
    public GameObject cornAnimation;

    [SerializeField]
    public GameObject redPepperAnimation;

    public MoneyManager2 mm;
    public PlayerTwo p2;

    private int randomValue;
    private float moveRate = 1f;
    private float nextMove;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShopRaycast2();
        ShopMovement();
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
    

    void ShopMovement()//Move the shop selector with \ and [
    {
        if(Input.GetKey(KeyCode.Backslash) && !isMoving)
        {
            StartCoroutine(MovePlayer(moveUpUnits));
        }
        if(Input.GetKey(KeyCode.LeftBracket) && !isMoving)
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

    void ShopRaycast2()
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "BuyBeet" && MoneyManager2.instance.money2 >= MoneyManager2.instance.beetCost)
            {
                PlayerTwo.instance.plantAnimation = beetAnimation;
            }
            if(hit.collider.tag == "BuyCabbage" && MoneyManager2.instance.money2 >= MoneyManager2.instance.cabbageCost)
            {
                PlayerTwo.instance.plantAnimation = cabbageAnimation;
            }
            if(hit.collider.tag == "BuyCarrot" && MoneyManager2.instance.money2 >= MoneyManager2.instance.carrotCost)
            {
                PlayerTwo.instance.plantAnimation = carrotAnimation;
            }
            if(hit.collider.tag == "BuyCorn" && MoneyManager2.instance.money2 >= MoneyManager2.instance.cornCost)
            {
                PlayerTwo.instance.plantAnimation = cornAnimation;
            }
            if(hit.collider.tag == "BuyRedPepper" && MoneyManager2.instance.money2 >= MoneyManager2.instance.redPepperCost)
            {
                PlayerTwo.instance.plantAnimation = redPepperAnimation;
            }
        }
    }

    public void AIShop()
    {
        ShopRaycast2();

        randomValue = Random.Range(1,5);
        if(randomValue == 1 && Time.time > nextMove && !isMoving)
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(MovePlayer(moveUpUnits));
        }
        else if(randomValue == 2 && Time.time > nextMove && !isMoving)
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(MovePlayer(moveDownUnits));
        }
        else if(randomValue == 3 && Time.time > nextMove && !isMoving)
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(MovePlayer(moveDownUnits));
        }
        else if(randomValue == 4 && Time.time > nextMove && !isMoving) 
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(MovePlayer(moveUpUnits));
        }
        else if(randomValue == 5 && Time.time > nextMove && !isMoving) 
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(MovePlayer(moveUpUnits));
        }

    }
}
