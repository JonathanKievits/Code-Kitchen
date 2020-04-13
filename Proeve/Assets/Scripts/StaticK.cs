using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticK : MonoBehaviour
{
    //this checks how many number of small ingredients have been inputted behind eachother
    public static int NumberSmalIngredient;
    //this checks which size the previous command had
    public static string PreviousCommandSize;
    //this string will be put in the outputTextfield
    public static string CommandString;
    //this will check if there is a wrong input
    public static bool WrongInput;
}
