using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDay : MonoBehaviour
{
    private int _customerAmount = 5;

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

    private void StartNextDay()
    {
        CheckDifficulty();
    }
}
