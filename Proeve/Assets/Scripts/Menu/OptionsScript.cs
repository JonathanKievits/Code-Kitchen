using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{

    //The difficulty is managed here from the options menu, afterwards this is used in orders to give harder orders the higher the difficulty.
    public void DifficultyManager(int difficulty)
    {
        switch (difficulty)
        {
            case 0:
                StaticK.Difficulty = 0;
                break;
            case 1:
                StaticK.Difficulty = 1;
                break;
            case 2:
                StaticK.Difficulty = 2;
                break;
        }

    }
}
