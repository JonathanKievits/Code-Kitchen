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
        Sad,
        Angry
    }

    public MoodState State;


    //Functions

    //Starts the state with happy
    void Start()
    {
        State = MoodState.Happy;    
    }

    //Raises the customer happyness
    public void RaiseHappyness()
    {
        switch (State)
        {
            case MoodState.Happy:
                break;
            case MoodState.Neutral:
                State = MoodState.Happy;
                break;
            case MoodState.Sad:
                State = MoodState.Neutral;
                break;
            case MoodState.Angry:
                State = MoodState.Sad;
                break;
            default:
                break;
        }
    }

    //Lowers the customer happyness
    public void LowerHappyness()
    {
        switch (State)
        {
            case MoodState.Happy:
                State = MoodState.Neutral;
                break;
            case MoodState.Neutral:
                State = MoodState.Sad;
                break;
            case MoodState.Sad:
                State = MoodState.Angry;
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
        State = state;
    }
}
