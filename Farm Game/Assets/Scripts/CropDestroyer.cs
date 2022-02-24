using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BuyCow")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BuySheep")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BuyChicken")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BuyPig")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BuyHorse")
        {
            Destroy(gameObject);
        }
    }
}

