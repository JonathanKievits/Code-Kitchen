using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CommandBlock : MonoBehaviour
{
    //this is the field that the player uses for code
    public GameObject InputField;
    //this will display what the player has typed
    public GameObject CodeDisplay;
    //this will display the wrong code
    public GameObject WrongCodeDispaly;
    //this is the spawn location of the ingredients in the middle
    public Transform SpawnPositionMiddle;
    //this is the spawn location of the ingredient on the left
    public Transform SpawnPositionLeft;
    //this is the spawn location of the ingredient on the right
    public Transform SpawnPositionRight;
    //this is the burger
    public GameObject Burger;
    //this is the lettuce
    public GameObject Lettuce;
    //this is the Tomato
    public GameObject Tomato;
    //this is the underbun
    public GameObject UnderBun;
    //this is the upperbun
    public GameObject UpperBun;
    //this is the hotdog
    public GameObject Hotdog;
    //this is the hotdog bun
    public GameObject HotdogBun;
    //this is the sauce
    public GameObject Mayonaise;
    //this is the pickle
    public GameObject Pickle;
    //this is the order
    public GameObject Order;
    //this is the cheese 
    public GameObject Cheese;
    //this is the bacon
    public GameObject Bacon;
    //this is the Union
    public GameObject Union;

    private Order _order;
    private string _commandCode;
    private string _multipleLines;
    private string _wrongMultipleLines;
    private float _respawsTime = 0.5f;
    private float _smallIngredientSpawnLocationX;
    private float _smallIngredientSpawnLocationZ;

    //this puts the command line in the textfield
    private void _storeCode()
    {
        _commandCode = InputField.GetComponent<Text>().text;
        StaticK.CommandString = _commandCode;
        string[] tmp = _commandCode.Split('(', /*',',*/ ')');
        try
        {
            int _intConverter = Int32.Parse(tmp[1]);
            int _costomerInt = /*Int32.Parse(tmp[2])*/2;
            _checkIngredient(tmp[0], _intConverter, _costomerInt);
        }
        catch (Exception e)
        {
            StaticK.WrongInput = true;
            StaticK.CommandString += " Dit is geen correcte code";
        }
        if (!StaticK.WrongInput)
        {
            _multipleLines = StaticK.CommandString + Environment.NewLine + _multipleLines;
            _wrongMultipleLines = "" + Environment.NewLine + _wrongMultipleLines;
            CodeDisplay.GetComponent<Text>().text = _multipleLines;
            WrongCodeDispaly.GetComponent<Text>().text = _wrongMultipleLines;
        }
        else
        {
            _multipleLines = "" + Environment.NewLine + _multipleLines;
            _wrongMultipleLines = StaticK.CommandString + Environment.NewLine + _wrongMultipleLines;
            CodeDisplay.GetComponent<Text>().text = _multipleLines;
            WrongCodeDispaly.GetComponent<Text>().text = _wrongMultipleLines;
            StaticK.WrongInput = false;
        }
        InputField.GetComponent<Text>().text = " ";
    }

    public void Apply()
    {
        _storeCode();
    }
    //this checks which ingredients has been requested and by which customer
    private void _checkIngredient(string _nameIngredient, int _numberOfIngredient, int _customerLocation)
    {
        bool NoLocation = false;
        var _localSpawnLocation = SpawnPositionMiddle;
        switch (_customerLocation)
        {
            case 1:
                _localSpawnLocation = SpawnPositionLeft;
                break;
            case 2:
                _localSpawnLocation = SpawnPositionMiddle;
                break;
            case 3:
                _localSpawnLocation = SpawnPositionRight;
                break;
            default:
                NoLocation = true;
                break;
        }
        if (!NoLocation)
            switch (_nameIngredient)
            {
                case "GetBurger":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(Burger, _numberOfIngredient, _localSpawnLocation, "BurgerPatty"));
                    break;
                case "GetOnderBroodje":
                    StaticK.PreviousCommandSize = "Round";
                    StaticK.PreviousBottom = "BurgerBottom";
                    StartCoroutine(_spawnIngredient(UnderBun, _numberOfIngredient, _localSpawnLocation, "BurgerBottomBun"));
                    break;
                case "GetSla":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(Lettuce, _numberOfIngredient, _localSpawnLocation, "Lettuce"));
                    break;
                case "GetTopBroodje":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(UpperBun, _numberOfIngredient, _localSpawnLocation, "BurgerTopBun"));
                    break;
                case "GetTomaat":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(Tomato, _numberOfIngredient, _localSpawnLocation, "Tomato"));
                    break;
                case "GetHotdog":
                    StaticK.PreviousCommandSize = "Long";
                    StartCoroutine(_spawnIngredient(Hotdog, _numberOfIngredient, _localSpawnLocation, "HotdogMeat"));
                    break;
                case "GetHotdogBroodje":
                    StaticK.PreviousCommandSize = "Long";
                    StaticK.PreviousBottom = "HotdogBottom";
                    StartCoroutine(_spawnIngredient(HotdogBun, _numberOfIngredient, _localSpawnLocation, "HotdogBase"));
                    break;
                case "GetAugruk":
                    StaticK.PreviousCommandSize = "Small";
                    StartCoroutine(_spawnIngredient(Pickle, _numberOfIngredient, _localSpawnLocation, "HotdogUnion"));
                    break;
                case "GetUitjes":
                    StaticK.PreviousCommandSize = "Small";
                    StartCoroutine(_spawnIngredient(Union, _numberOfIngredient, _localSpawnLocation, "BurgerUnion"));
                    break;
                case "GetMayonaise123":
                    StaticK.PreviousCommandSize = "Long";
                    StartCoroutine(_spawnIngredient(Mayonaise, _numberOfIngredient, _localSpawnLocation, "BurgerSauce"));
                    break;
                case "GetKetchup":
                    StaticK.PreviousCommandSize = "Long";
                    StartCoroutine(_spawnIngredient(Mayonaise, _numberOfIngredient, _localSpawnLocation, "HotdogSauce"));
                    break;
                case "GetKaas":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(Cheese, _numberOfIngredient, _localSpawnLocation, "Cheese"));
                    break;
                case "GetSpek":
                    StaticK.PreviousCommandSize = "BurgerLong";
                    StartCoroutine(_spawnIngredient(Bacon, _numberOfIngredient, _localSpawnLocation, "Bacon"));
                    break;
                case "GetPizzaBottom":
                    StaticK.PreviousCommandSize = "Pizza";
                    StaticK.PreviousBottom = "PizzaBottom";
                    StartCoroutine(_spawnIngredient(Bacon, _numberOfIngredient, _localSpawnLocation, "Pizza"));
                    break;
                case "Klaar":
                    GiveCustomerFood(_localSpawnLocation);
                    break;
                default:
                    StaticK.CommandString = _nameIngredient + " bestaat niet";
                    StaticK.WrongInput = true;
                    break;
            }
        else
        {
            StaticK.CommandString = "Klant(" + _customerLocation + ")"; StaticK.WrongInput = true;
        }
    }
    //this spawns the ingredients
    IEnumerator _spawnIngredient(GameObject _whatSpawned, int _numberOfIngredients, Transform _ingredientSpawnLocation, string _ingredientName)
    {
        int _i = 1;
        while (_i <= _numberOfIngredients)
        {
            switch (StaticK.PreviousBottom)
            {
                case "HotdogBottom":
                    switch (StaticK.NumberSmalIngredient)
                    {
                        case 0:
                            _smallIngredientSpawnLocationX = 0.7f; _smallIngredientSpawnLocationZ = 0f;
                            break;
                        case 1:
                            _smallIngredientSpawnLocationX = 0f; _smallIngredientSpawnLocationZ = 0f;
                            break;
                        case 2:
                            _smallIngredientSpawnLocationX = 1.4f; StaticK.NumberSmalIngredient = -1; _smallIngredientSpawnLocationZ = 0f;
                            break;
                    }
                    break;
                case "BurgerBottom":
                    switch (StaticK.NumberSmalIngredient)
                    {
                        case 0:
                            _smallIngredientSpawnLocationX = 0.03f; _smallIngredientSpawnLocationZ = 0.18f;
                            break;
                        case 1:
                            _smallIngredientSpawnLocationX = 0.1f; _smallIngredientSpawnLocationZ = 0.18f;
                            break;
                        case 2:
                            _smallIngredientSpawnLocationX = 0.03f; _smallIngredientSpawnLocationZ = 0.114f;
                            break;
                        case 3:
                            _smallIngredientSpawnLocationX = 0.1f; _smallIngredientSpawnLocationZ = 0.114f; StaticK.NumberSmalIngredient = -1;
                            break;
                    }
                    break;
                default:
                    _smallIngredientSpawnLocationX = 0.044f; _smallIngredientSpawnLocationZ = 0.01f; StaticK.NumberSmalIngredient = -1;
                    break;
            }
            if (StaticK.PreviousCommandSize == "Round" || StaticK.PreviousCommandSize == "Long" || StaticK.PreviousCommandSize == "BurgerLong" || StaticK.PreviousCommandSize == "PizzaRound")
            {
                yield return new WaitForSeconds(_respawsTime);
                GameObject _gameObject = Instantiate(_whatSpawned, _ingredientSpawnLocation) as GameObject;
                _whatSpawned.name = _ingredientName;
                StaticK.NumberSmalIngredient = 0;
                _i++;
            }
            else if (StaticK.PreviousCommandSize == "Small")
            {
                int _rotation = 0;
                if (_ingredientName == "HotdogUnion")
                    _rotation = -110;
                yield return new WaitForSeconds(_respawsTime);
                GameObject _gameObject = Instantiate(_whatSpawned, new Vector3(_ingredientSpawnLocation.position.x + _smallIngredientSpawnLocationX, _ingredientSpawnLocation.position.y, _ingredientSpawnLocation.position.z + _smallIngredientSpawnLocationZ), Quaternion.Euler(_rotation,0,0)) as GameObject;
                StaticK.NumberSmalIngredient++;
                _whatSpawned.name = _ingredientName;
                _gameObject.transform.SetParent(_ingredientSpawnLocation.transform);
                _i++;
            }
        }
    }
    //this will give the ingredients to the customer
    public void GiveCustomerFood(Transform _ingredientSpawnLocation)
    {
        int TempInt = 6;
        for (int i = 0; i < _ingredientSpawnLocation.childCount; i++)
        {
            print(Order.transform.childCount);
            string _orderIngredient = "place" + (/*Order.transform.childCount*/TempInt - i);
            var _trueOrderIngredient = Order.transform.Find(_orderIngredient).GetChild(0);
            var _falseOrderIngredient = _ingredientSpawnLocation.GetChild(i);
            string[] tmp = _falseOrderIngredient.transform.name.Split('(');
            if (tmp[0] != _trueOrderIngredient.transform.name)
            {
                StaticK.CommandString = "Dit is niet wat ik had gevraagd!";
                StaticK.WrongInput = true;
                break;
            }
        }
        foreach (Transform child in _ingredientSpawnLocation.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        if(!StaticK.WrongInput && _ingredientSpawnLocation.childCount != 0)
            StaticK.CommandString = "Bedankt voor het eten!";
    }
}

