using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[Serializable]
public class TreeState : BaseState
{
    public bool saved;
}

[Serializable]
public class TreeSM :BaseSM
{
    public List<TreeState> states = new List<TreeState>();

    public override void NextState(string input)
    {
        string nextStateName = currentState.GetNextState(input);
        if (nextStateName == null)
        {
            Debug.LogError("Null stateName. CurrentState: " + currentState.name +
                "\nInput: " + input);
        }
        currentState = StateFromName(nextStateName);
        Debug.Log("NEW current state for " + name +" : " + currentState.name);
    }

    public override void Reset()
    {
        // set the current state to the starting state
        currentState = StateFromName(startingState);
    }

    public override BaseState StateFromName(string stateName)
    {
        // find a State from the given state name
        foreach (TreeState state in states)
        {
            if (stateName == state.name)
            {
                return state;
            }
        }
        // log that no match was found and return the first on in the list
        Debug.LogError("Attempted to access a state that isn't in the list. " +
            "CurrentState: " + currentState.name + ". StateName: " + stateName);
        return states[0];
    }
}
