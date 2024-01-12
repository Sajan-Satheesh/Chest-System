using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestStateMachine
{
    public ChestState currentState;
    private ChestController chestContoller;
    public List<ChestState> states = new List<ChestState>();

    public ChestStateMachine(ChestController _controller)
    {
        chestContoller = _controller;
        
    }
    public void InitializeState(ChestStates newChestState)
    {
        states.Add(new ChestState_UnLocking(chestContoller));
        currentState = GetState(newChestState);
        currentState.OnEnter();
    }

    public void SetState(ChestStates newChestState)
    {
        if (currentState.thisChestState != newChestState)
        {
            currentState.OnExit();
            currentState = GetState(newChestState);
            currentState.OnEnter();
        }
    }
    private ChestState GetState(ChestStates newChestState)
    {  
        foreach (ChestState state in states)
        {
            if (state.thisChestState == newChestState)
            {
                return state;
            }
        }
        return AddState(newChestState);
        
    }

    private ChestState AddState(ChestStates newChestState)
    {
        switch (newChestState)
        {
            case ChestStates.LOCKED:
                states.Add(new ChestState_Locked(chestContoller));
                break;
            case ChestStates.UNLOCKED:
                states.Add(new ChestState_Unlocked(chestContoller));
                break;
            case ChestStates.UNLOCKING:
                states.Add(new ChestState_UnLocking(chestContoller));
                break;
            case ChestStates.IN_QUEUE:
                states.Add(new ChestState_InQueue(chestContoller));
                break;
            case ChestStates.REMOVE:
                states.Add(new ChestState_Remove(chestContoller));
                break;
            default:
                break;
        }
        return states.Last();
    }
}
