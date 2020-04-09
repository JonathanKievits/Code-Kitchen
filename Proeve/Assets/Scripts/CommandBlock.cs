using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandBlock : MonoBehaviour
{
    //this is the field that the player uses for code
    public GameObject InputField;
    //this will display what the player has typed
    public GameObject CodeDisplay;
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

    private string _commandCode;
    private string _multipleLines;
    private float _respawsTime = 0.5f;

    //this puts the command line in the textfield
    private void _storeCode()
    {
        _commandCode = InputField.GetComponent<Text>().text;
        string[] tmp = _commandCode.Split('(', ')', '(', ')');
        int _intConverter = Int32.Parse(tmp[1]);
        int _costomerInt = Int32.Parse(tmp[3]);
        if(tmp[2] == "Klant")
            _checkIngredient(tmp[0], _intConverter, _costomerInt);
        _multipleLines = _commandCode + Environment.NewLine + _multipleLines;
        CodeDisplay.GetComponent<Text>().text = _multipleLines;
        InputField.GetComponent<Text>().text = "";
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
            case 1: _localSpawnLocation = SpawnPositionLeft;
                break;
            case 2:
                _localSpawnLocation = SpawnPositionMiddle;
                break;
            case 3:
                _localSpawnLocation = SpawnPositionRight;
                break;
            default: NoLocation = true;
                break;
        }
        if (!NoLocation)
            switch (_nameIngredient)
            {
                case "GetBurger":
                    StartCoroutine(_spawnIngredient(Burger, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetUnderBun":
                    StartCoroutine(_spawnIngredient(UnderBun, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetLettuce":
                    StartCoroutine(_spawnIngredient(Lettuce, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetUpperBun":
                    StartCoroutine(_spawnIngredient(UpperBun, _numberOfIngredient, _localSpawnLocation));
                    break;
                case "GetTomato":
                    StartCoroutine(_spawnIngredient(Tomato, _numberOfIngredient, _localSpawnLocation));
                    break;
                default:
                    _nameIngredient = _nameIngredient + " bestaat niet";
                    break;
            }
        else
            _nameIngredient = "Klant(" + _customerLocation + ")";
    }
    //this spawns the ingredients
    IEnumerator _spawnIngredient(GameObject _whatSpawned, int _numberOfIngredients, Transform _ingredientSpawnLocation)
    {
        int _i = 1;
        while (_i <= _numberOfIngredients)
        {
            yield return new WaitForSeconds(_respawsTime);
            GameObject _gameObject = Instantiate(_whatSpawned, _ingredientSpawnLocation) as GameObject;
            _i++;
        }
    }
}
