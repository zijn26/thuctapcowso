using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public IPlayerState currentState;

    public void ChangState(IPlayerState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterStae();
        Debug.Log("State is: " + currentState.GetType().Name);
    }
    public void InnitState(IPlayerState newState)
    {
        currentState = newState;
        currentState.EnterStae();
    }
}
