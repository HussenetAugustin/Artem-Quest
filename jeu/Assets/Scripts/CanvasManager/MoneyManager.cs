using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyManager : MonoBehaviour
{
    public Text MoneyDisplay;
    public FloatValue MoneyAmount;

    // Start is called before the first frame update
    void Start()
    {
        MoneyAmount.RuntimeValue = MoneyAmount.initialValue;
        AmountUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AmountUpdate()
    {
        string amount = "";
        for (int i=0; i<4-MoneyAmount.RuntimeValue.ToString().Length; i++)
        {
            amount += "0";
        }
        amount += MoneyAmount.RuntimeValue.ToString();
        MoneyDisplay.text = amount;
    }
}
