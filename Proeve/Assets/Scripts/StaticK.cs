using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticK : MonoBehaviour
{
    //this checks how many number of small ingredients have been inputted behind eachother
    public static int NumberSmalIngredient;
    //this checks which size the previous command had
    public static string PreviousCommandSize;
    //this checks which size the bottom is
    public static string PreviousBottom;
    //this string will be put in the outputTextfield
    public static string CommandString;
    //this will check if there is a wrong input
    public static bool WrongInput;
    //this will check what the game difficulty is
    public static int Difficulty =1;
    //this will check if you are allowd to typ
    public static bool Activate;
    //This will check how many customers are left
    public static int CustomersLeft;
}
