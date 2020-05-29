using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _canvases;

    //Opens the selected canvas
    public void OpenCanvas(int num)
    {
        if (InRange(num))
        {
            _canvases[num].SetActive(true);
        }
    }

    //Closes the selected canvas
    public void CloseCanvas(int num)
    {
        if (InRange(num))
        {
            _canvases[num].SetActive(false);
        }
    }

    //Checks if the selected number is accasable
    private bool InRange(int num)
    {
        if (num < _canvases.Length)
        {
            return true;
        }
        else
        {
            Debug.LogWarning("Number out of range: Open Canvas Number");
            return false;
        }
    }
}
