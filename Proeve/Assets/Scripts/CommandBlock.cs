using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

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

    private string _commandCode;
    private string _multipleLines;
    private string _wrongMultipleLines;
    private float _respawsTime = 0.5f;
    private float _smallIngredientSpawnLocation;

    //this puts the command line in the textfield
    private void _storeCode()
    {
        _commandCode = InputField.GetComponent<Text>().text;
        StaticK.CommandString = _commandCode;
        string[] tmp = _commandCode.Split('(', ')', '(', ')');
        try
        {
            int _intConverter = Int32.Parse(tmp[1]);
            int _costomerInt = Int32.Parse(tmp[3]);
            if (tmp[2] == "Klant")
            {
                _checkIngredient(tmp[0], _intConverter, _costomerInt);
                StaticK.WrongInput = false;
            }
        } 
        catch
        {
            StaticK.WrongInput = true;
            StaticK.CommandString = StaticK.CommandString + " Dit is geen correcte code";
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
                    StartCoroutine(_spawnIngredient(Burger, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetUnderBun":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(UnderBun, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetLettuce":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(Lettuce, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetUpperBun":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(UpperBun, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetTomato":
                    StaticK.PreviousCommandSize = "Round";
                    StartCoroutine(_spawnIngredient(Tomato, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetHotdog":
                    StaticK.PreviousCommandSize = "Long";
                    StartCoroutine(_spawnIngredient(Hotdog, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetHotdogBun":
                    StaticK.PreviousCommandSize = "Long";
                    StartCoroutine(_spawnIngredient(HotdogBun, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetPickle":
                    StaticK.PreviousCommandSize = "Small";
                    StartCoroutine(_spawnIngredient(Pickle, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetMayonaise":
                    StaticK.PreviousCommandSize = "Long";
                    StartCoroutine(_spawnIngredient(Mayonaise, _numberOfIngredient, _localSpawnLocation));
                    break;
                default:
                    StaticK.CommandString = _nameIngredient + " bestaat niet";
                    StaticK.WrongInput = true;
                    break;
            }
        else
            StaticK.CommandString = "Klant(" + _customerLocation + ")"; StaticK.WrongInput = true;
    }
    //this spawns the ingredients
    IEnumerator _spawnIngredient(GameObject _whatSpawned, int _numberOfIngredients, Transform _ingredientSpawnLocation)
    {
        int _i = 1;
        
        while (_i <= _numberOfIngredients)
        {
            switch (StaticK.NumberSmalIngredient)
            {
                case 0:
                    _smallIngredientSpawnLocation = 0.7f;
                    break;
                case 1:
                    _smallIngredientSpawnLocation = 0f;
                    break;
                case 2:
                    _smallIngredientSpawnLocation = 1.4f; StaticK.NumberSmalIngredient = 0;
                    break;
            } 

            if (StaticK.PreviousCommandSize == "Round" || StaticK.PreviousCommandSize == "Long") 
            { 
                yield return new WaitForSeconds(_respawsTime);
                GameObject _gameObject = Instantiate(_whatSpawned, _ingredientSpawnLocation) as GameObject;
                StaticK.NumberSmalIngredient = 0;
                _i++;
            }
            else if(StaticK.PreviousCommandSize == "Small")
            {
                yield return new WaitForSeconds(_respawsTime);
                GameObject _gameObject = Instantiate(_whatSpawned, new Vector3(_ingredientSpawnLocation.position.x + _smallIngredientSpawnLocation, _ingredientSpawnLocation.position.y, _ingredientSpawnLocation.position.z), Quaternion.identity) as GameObject;
                StaticK.NumberSmalIngredient++;
                _i++;
            }
        }
    }
}

