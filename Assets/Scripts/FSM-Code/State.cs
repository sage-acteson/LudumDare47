using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StateTransition
{
    [Tooltip("Input to the SM. Leave as 'any' to take any input.")]
    public string input;
    public string nextState;
}

[Serializable]
public class BaseState
{
    public string name;
    public List<StateTransition> transitions;

    public string GetNextState(string input)
    {
        for( int i = 0; i < transitions.Count; i++)
        {
            // if it matches the transition input or if the transition takes 'any' input
            if(input == transitions[i].input || transitions[i].input == "any")
            {
                return transitions[i].nextState;
            }
        }
        return null;
    }
}

[Serializable]
public abstract class BaseSM
{
    public string name;
    public string startingState;
    protected BaseState currentState;

    public abstract void nextState(string input);
    public abstract void reset();

    // TODO possibly store the states using polymorphism so this can be implemented here
    public abstract BaseState stateFromName(string stateName);
}