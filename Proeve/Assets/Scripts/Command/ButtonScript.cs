using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //this is the Spawner
    public GameObject Spawner;
    //these are the ingredients
    public GameObject Ingredients;
    //this is the Next ingredient button
    public GameObject Button;
    //this is the dienblad
    public GameObject Dienblad;

    private bool _replacement = false;
    private bool _Deactiavetd = true;

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

    public void Activator()
    {
        if (_Deactiavetd)
        {
            Spawner.SetActive(false);
            Ingredients.SetActive(true);
            Dienblad.SetActive(false);
            Button.SetActive(true);
            _Deactiavetd = false;
            StaticK.Activate = true;
        }
        else
        {
            Spawner.SetActive(true);
            Ingredients.SetActive(false);
            Dienblad.SetActive(true);
            Button.SetActive(false);
            _Deactiavetd = true;
            StaticK.Activate = false;
        }
    }
}
