using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
