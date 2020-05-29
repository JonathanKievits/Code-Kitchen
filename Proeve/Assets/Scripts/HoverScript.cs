using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverScript : MonoBehaviour
{
    //this will display which text you want to use
    public string DisplayString;
    //this will search for the text this scirpt is bound
    public Text DisplayText;
    
    

    private bool _displayInfo;
    private float _fadeTime = 10;
    private bool _replacement = false;

    void Start()
    {
        string DisplayName = DisplayText.name;
        DisplayText = GameObject.Find(DisplayName).GetComponent<Text>();
        //DisplayText.color = Color.black;
    }

    void Update()
    {
        FadeText();
    }

    private void OnMouseOver()
    {
        _displayInfo = true;
    }

    private void OnMouseExit()
    {
        _displayInfo = false;
    }

    public void NextIngredient(GameObject Display)
    {
        var _replace = Display.transform.Find("Foodtrays01 prefab");
        var _replace2 = Display.transform.Find("Foodtrays02 prefab");
        if (!_replacement)
        {
            _replace2.gameObject.SetActive(true);
            _replace.gameObject.SetActive(false);
            _replacement = true;
        }
        else
        {
            _replace2.gameObject.SetActive(false);
            _replace.gameObject.SetActive(true);
            _replacement = false;
        }
        
    }

    void FadeText()
    {
        if (_displayInfo)
        {
            DisplayText.text = DisplayString;
            DisplayText.color = Color.Lerp(DisplayText.color, Color.blue, _fadeTime * Time.deltaTime);
        }
        else
        {
            DisplayText.color = Color.Lerp(DisplayText.color, Color.clear, _fadeTime * Time.deltaTime);
        }
    }
}
