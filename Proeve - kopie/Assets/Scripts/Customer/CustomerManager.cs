using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //Scripts
    [SerializeField] private Happyness _happyness;
    [SerializeField] private Order _order;
    [SerializeField] private Timer _timer;

    //variables
    private float _newCustomerTime = 10f;
    private float _customerPatience = 5f;

    void Start()
    {
        if (_timer.NextActivation(_newCustomerTime))
        {
            //_order.GenerateOrder();
        }

        if (_timer.NextActivation(_customerPatience))
        {
            _happyness.LowerHappyness();
        }
    }
}
