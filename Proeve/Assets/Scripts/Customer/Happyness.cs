using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happyness : MonoBehaviour
{
    //Variables
    //Enum with the happyness states
    public enum MoodState
    {
        Happy,
        Neutral,
        Angry
    }

    private MoodState _state;


    //Functions

    //Starts the state with happy
    void Start()
    {
        _state = MoodState.Happy;    
    }

    //Raises the customer happyness
    public void RaiseHappyness()
    {
        switch (_state)
        {
            case MoodState.Happy:
                break;
            case MoodState.Neutral:
                _state = MoodState.Happy;
                break;
            case MoodState.Angry:
                _state = MoodState.Neutral;
                break;
            default:
                break;
        }
    }

    //Lowers the customer happyness
    public void LowerHappyness()
    {
        switch (_state)
        {
            case MoodState.Happy:
                _state = MoodState.Neutral;
                break;
            case MoodState.Neutral:
                _state = MoodState.Angry;
                break;
            case MoodState.Angry:
                break;
            default:
                break;
        }
    }

    //Changes the customer happyness with given state
    public void SetHappyness(MoodState state)
    {
        _state = state;
    }
}
