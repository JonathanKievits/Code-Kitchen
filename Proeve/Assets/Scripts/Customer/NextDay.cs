using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
    //this will display the customers left
    public Text DisplayText;

    [SerializeField]
    private Text _dayText = null;

    private void Update()
    {
        DisplayText.text = StaticK.CustomersLeft.ToString() + ": Klanten over";
        _dayText.text = "Dag: " + StaticK.CurrentDay.ToString();
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
        
        StaticK.CustomersLeft += StaticK.CurrentDay;
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
        StaticK.CurrentDay += 1;
        _dayText.text = "Day " + StaticK.CurrentDay;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
