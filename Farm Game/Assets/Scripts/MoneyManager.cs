using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField]
    public Text moneyText;

    [SerializeField]
    public int money;
    [SerializeField]
    public int beetAmount;

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
        moneyText.text = "$" + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney()
    {
        money += beetAmount;
        moneyText.text = "$" + money.ToString();
    }
}
