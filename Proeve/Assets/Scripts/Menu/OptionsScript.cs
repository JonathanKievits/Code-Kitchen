using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{

    //The difficulty is managed here from the options menu, afterwards this is used in orders to give harder orders the higher the difficulty.
    public void DifficultyEasy()
    {
        StaticK.Difficulty = 0;
    }
    public void DifficultyNormal()
    {
        StaticK.Difficulty = 1;
    }
    public void DifficultyHard()
    {
        StaticK.Difficulty = 2;
    }
}
