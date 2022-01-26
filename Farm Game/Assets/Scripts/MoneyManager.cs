using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private int money;
    [SerializeField]
    private int beetAmount;

    private void Awake() 
    {
        instance = this;
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
