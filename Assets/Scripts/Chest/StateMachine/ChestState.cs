using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChestState 
{
    protected ChestController controller;
    protected bool updateState = false;
    //public abstract ChestStates thisChestState{ get;  protected set; }
    public ChestStates thisChestState { get; protected set; }

    public ChestState(ChestController _chestControlller, ChestStates _thisState)
    {
        controller = _chestControlller;
        thisChestState = _thisState;
    }
    public abstract void OnEnter();
    public virtual void OnExit() { updateState = false; }
    public virtual void OnTick()
    {
        if (!updateState) return;
    }

}
