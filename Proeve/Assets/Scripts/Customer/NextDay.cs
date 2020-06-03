using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDay : MonoBehaviour
{
    //this will display the customers left
    public Text DisplayText;

    [SerializeField]
    private Text _dayText = null;
    
    private int _currentDay = 0;

    private void Update()
    {
        DisplayText.text = StaticK.CustomersLeft.ToString() + ": Klanten over";
        _dayText.text = "Dag: " + _currentDay.ToString();
    }
    void Start()
    {
        SetCustomerAmount();
    }

    //Sets difficulty for amount of customers
    private void SetCustomerAmount()
    {
        switch (StaticK.Difficulty)
        {
            case 0:
                StaticK.CustomersLeft = 5;
                break;
            case 1:
                StaticK.CustomersLeft = 8;
                break;
            case 2:
                StaticK.CustomersLeft = 10;
                break;
        }
        
        StaticK.CustomersLeft += _currentDay;
    }
    
    //Lowers the amount of customers
    public void LowerAmount()
    {
        if (StaticK.CustomersLeft > 1)
        {
            StaticK.CustomersLeft -= 1;
        }
        else
        {
            StaticK.CustomersLeft -= 1;
            StartNextDay();
        }     
    }

    //resets the customer amount, and starts a new day
    private void StartNextDay()
    {
        SetCustomerAmount();
        _currentDay += 1;
        _dayText.text = "Day " + _currentDay;
    }
}
