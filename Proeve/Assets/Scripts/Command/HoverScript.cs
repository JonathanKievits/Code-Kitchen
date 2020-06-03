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
    //this will display the Order;
    public GameObject DisplayOrder;
    //this will show if the customer is ready to order
    public bool ReadyToOrder = true;
    
    
    

    private bool _displayInfo;
    private float _fadeTime = 10;
    

    void Start()
    {
        string DisplayName = DisplayText.name;
        DisplayText = GameObject.Find(DisplayName).GetComponent<Text>();
    }

    void Update()
    {
        if(ReadyToOrder)
            FadeText();
    }

    private void OnMouseOver()
    {
        DisplayOrder.SetActive(true);
        _displayInfo = true;
    }

    private void OnMouseExit()
    {
        _displayInfo = false;
        DisplayOrder.SetActive(false);
    }

    

    void FadeText()
    {
        
        if (_displayInfo)
        {
            var _color = new Color32(229, 106, 106, 255);
            DisplayText.text = DisplayString;
            DisplayText.color = Color.Lerp(DisplayText.color, _color, _fadeTime * Time.deltaTime);
        }
        else
        {
            DisplayText.color = Color.Lerp(DisplayText.color, Color.clear, _fadeTime * Time.deltaTime);
        }
        
    }
}
