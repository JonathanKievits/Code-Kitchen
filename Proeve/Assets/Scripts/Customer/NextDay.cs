using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDay : MonoBehaviour
{
    [SerializeField]
    private Text _dayText = null;

    private int _customerAmount = 5;
    private int _currentDay = 0;

    void Start()
    {
        CheckDifficulty();
    }

    //Sets difficulty for amount of customers
    private void CheckDifficulty()
    {
        switch (StaticK.Difficulty)
        {
            case 0:
                _customerAmount = 5;
                break;
            case 1:
                _customerAmount = 8;
                break;
            case 2:
                _customerAmount = 10;
                break;
        }
    }
    
    //Lowers the amount of customers
    public void LowerAmount()
    {
        if (_customerAmount > 1)
        {
            _customerAmount -= 1;
        }
        else
        {
            _customerAmount -= 1;
            StartNextDay();
        }     
    }

    //resets the customer amount, and starts a new day
    private void StartNextDay()
    {
        CheckDifficulty();
        _currentDay += 1;
        _dayText.text = "Day " + _currentDay;
    }
}
