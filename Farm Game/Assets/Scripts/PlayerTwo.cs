using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    //Written by Minsung Lee and edited by Edwin Aguirre
    //This script allows the player to move in a grid layout
    //It also uses perfect movement so that the Selector or player can be directly above each plot

    public static PlayerTwo instance;

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private Vector3 moveRightUnits = new Vector3(0.9f,0,0);
    private Vector3 moveLefttUnits = new Vector3(-0.9f,0,0);
    private Vector3 moveUpUnits = new Vector3(0,0,0.9f);
    private Vector3 moveDownUnits = new Vector3(0,0,-0.9f);

    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private Mesh emptyPlotMesh;

    [SerializeField]
    public GameObject plantAnimation;

    [SerializeField]
    public GameObject emptyPlot;

    [SerializeField]
    private GameObject vegetableSpawner;
    [SerializeField]
    private GameObject beet;
    [SerializeField]
    private GameObject cabbage;
    [SerializeField]
    private GameObject carrot;
    [SerializeField]
    private GameObject corn;
    [SerializeField]
    private GameObject redPepper;
    [SerializeField]
    public float placeX;
    [SerializeField]
    public float placeY;
    [SerializeField]
    public float placeZ;
    [SerializeField]
    private float chance;

    [SerializeField]
    private MoneyManager2 mm;

    [SerializeField]
    public int plotAmount;

    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTwoMovement();
        WallRightRaycast();
        WallLeftRaycast();
        WallUpRaycast();
        WallDownRaycast();

        MeshRaycast2();
        placeX = Random.Range(4.5f, 8.1f);
        placeY = Random.Range(0, 2.6f);
        placeZ = Random.Range(4.5f, 9.9f);
        if (mm.money2 <= 0)
        {
            mm.money2 = 0;
            mm.moneyText2.text = "P2 " + mm.money2.ToString("C");
        }
    }

    public IEnumerator MovePlayer(Vector3 direction)
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

    private void PlayerTwoMovement()//Moving with arrow keys in a grid layout
    {
        if(Input.GetButton("P2MoveUp") && !isMoving || Input.GetAxisRaw("P2MoveUp") > 0f && !isMoving || -Input.GetAxisRaw("P2XboxVertical") > 0f && !isMoving)
        {
            StartCoroutine(MovePlayer(moveUpUnits));
        }
        if(Input.GetButton("P2MoveDown") && !isMoving || Input.GetAxisRaw("P2MoveDown") > 0f && !isMoving || Input.GetAxisRaw("P2XboxVertical") > 0f && !isMoving)
        {
            StartCoroutine(MovePlayer(moveDownUnits));
        }
        if(Input.GetButton("P2MoveRight") && !isMoving || Input.GetAxisRaw("P2MoveRight") > 0f && !isMoving || Input.GetAxisRaw("P2XboxHorizontal") > 0f && !isMoving)
        {
            StartCoroutine(MovePlayer(moveRightUnits));
        }
        if(Input.GetButton("P2MoveLeft") && !isMoving || Input.GetAxisRaw("P2MoveLeft") > 0f && !isMoving || -Input.GetAxisRaw("P2XboxHorizontal") > 0f && !isMoving)
        {
            StartCoroutine(MovePlayer(moveLefttUnits));
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

    public void MeshRaycast2()//Used to detect the squares/plots on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "Buy" && Input.GetButtonDown("P2Plant"))
            {
                BuyPlot2();
            }
            if (hit.collider.tag == "Plant" && Input.GetButtonDown("P2Plant"))//If the player has enough money, they can plant a vegetable by pressing return/enter key
            {
                BuyVegetable2();
            }
            else if (hit.collider.tag == "Collect" && Input.GetButtonDown("P2Plant"))
            {
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                CollectVegetable2();
                SoundManagerScript.PlaySound("footstep_grass_004");
            }
        }
    }

    public void BuyVegetable2()//Takes away money when each vegetable is bought by planting it
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if (plantAnimation.tag == "Beet" && mm.money2 >= mm.beetCost)
            {
                mm.LoseMoney2(mm.beetCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (plantAnimation.tag == "Cabbage" && mm.money2 >= mm.cabbageCost)
            {
                mm.LoseMoney2(mm.cabbageCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (plantAnimation.tag == "Carrot" && mm.money2 >= mm.carrotCost)
            {
                mm.LoseMoney2(mm.carrotCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (plantAnimation.tag == "Corn" && mm.money2 >= mm.cornCost)
            {
                mm.LoseMoney2(mm.cornCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (plantAnimation.tag == "RedPepper" && mm.money2 >= mm.redPepperCost)
            {
                mm.LoseMoney2(mm.redPepperCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
        }
    }

    public void CollectVegetable2()//Collects the vegetable and gives player money
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if (hit.collider.transform.parent.tag == "Beet")
            {
                mm.AddMoney2(mm.beetAmount);
                if (Random.value <= chance)
                {
                    Instantiate(beet, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);//When the player collects the vegetable, there is a chance of spawning that vegetable in the animal pen
                }
            }
            if (hit.collider.transform.parent.tag == "Cabbage")
            {
                mm.AddMoney2(mm.cabbageAmount);
                if (Random.value <= chance)
                {
                    Instantiate(cabbage, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if (hit.collider.transform.parent.tag == "Carrot")
            {
                mm.AddMoney2(mm.carrotAmount);
                if (Random.value <= chance)
                {
                    Instantiate(carrot, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if (hit.collider.transform.parent.tag == "Corn")
            {
                mm.AddMoney2(mm.cornAmount);
                if (Random.value <= chance)
                {
                    Instantiate(corn, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if (hit.collider.transform.parent.tag == "RedPepper")
            {
                mm.AddMoney2(mm.redPepperAmount);
                if (Random.value <= chance)
                {
                    Instantiate(redPepper, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
        }
    }

    public void BuyPlot2()//Buys the plot of land
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.transform.parent.tag == "Buy10" && mm.money2 >= mm.plotTenCost)
            {
                mm.LoseMoney2(mm.plotTenCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                plotAmount++;
            }
            if(hit.collider.transform.parent.tag == "Buy40" && mm.money2 >= mm.plotFortyCost)
            {
                mm.LoseMoney2(mm.plotFortyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                plotAmount++;
            }
            if(hit.collider.transform.parent.tag == "Buy70" && mm.money2 >= mm.plotSeventyCost)
            {
                mm.LoseMoney2(mm.plotSeventyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                plotAmount++;
            }
            if(hit.collider.transform.parent.tag == "Buy100" && mm.money2 >= mm.plotHundredCost)
            {
                mm.LoseMoney2(mm.plotHundredCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                plotAmount++;
            }
        }
    }
}

