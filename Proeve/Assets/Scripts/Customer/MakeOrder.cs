using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeOrder : MonoBehaviour
{
    private List<GameObject> _orderHolder;
    [SerializeField] private List<GameObject> _Ingredients;
    private void Start()
    {
        int order = Random.Range(0, 2);
        switch (order)
        {
            case 0:
                HamBurger();
                break;
            case 1:
                HotDog();
                break;
            case 2:
                Pizza();
                break;
        }
    }

    private void HamBurger()
    {
        _orderHolder.Add(_Ingredients[0]);
        _orderHolder.Add(_Ingredients[Random.Range(4,5)]);
        _orderHolder.Add(_Ingredients[2]);
        _orderHolder.Add(_Ingredients[1]);
    }
    private void HotDog()
    {
        _orderHolder.Add(_Ingredients[8]);
        _orderHolder.Add(_Ingredients[9]);
        _orderHolder.Add(_Ingredients[2]);
        _orderHolder.Add(_Ingredients[3]);
    }
    private void Pizza()
    {
        _orderHolder.Add(_Ingredients[7]);
        _orderHolder.Add(_Ingredients[3]);
        _orderHolder.Add(_Ingredients[6]);
        _orderHolder.Add(_Ingredients[5]);
    }
}
