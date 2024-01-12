using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestState_Locked : ChestState
{

    public ChestState_Locked(ChestController _chestControlller) : base(_chestControlller, ChestStates.LOCKED)
    {
    }

    //public override ChestStates thisChestState { get => thisChestState; protected set => thisChestState = ChestStates.locked; }

    public override void OnEnter()
    {
        LockChest();
        updateState = true;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnTick()
    {
        base.OnTick();
    }
    private void LockChest()
    {
        controller.SetChestDisplaySprite(controller.chestModel.lockedImage);
        controller.chestView.chestSelfButton.enabled = false;
        controller.SetChestTextStatus("Chest Locked");
    }
}
