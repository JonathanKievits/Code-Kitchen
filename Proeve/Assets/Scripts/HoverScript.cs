using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverScript : MonoBehaviour
{
    public string DisplayString;
    public Text DisplayText;

    private bool _displayInfo;
    private float _fadeTime = 10;

    void Start()
    {
        DisplayText = GameObject.Find("BurgerText").GetComponent<Text>();
        DisplayText.color = Color.clear;
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

    void FadeText()
    {
        if (_displayInfo)
        {
            DisplayText.text = DisplayString;
            DisplayText.color = Color.Lerp(DisplayText.color, Color.black, _fadeTime * Time.deltaTime);
        }
        else
        {
            DisplayText.color = Color.Lerp(DisplayText.color, Color.clear, _fadeTime * Time.deltaTime);
        }
    }
}
