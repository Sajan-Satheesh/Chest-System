using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestState_Unlocked : ChestState
{
    public ChestState_Unlocked(ChestController _chestControlller) : base(_chestControlller, ChestStates.UNLOCKED)
    {
    }

    //public override ChestStates thisChestState { get => thisChestState; protected set => thisChestState = ChestStates.unlocked; }

    public override void OnEnter()
    {
        unlockChest();
        updateState = true;
    }

    private void unlockChest()
    {
        SpendCurrency(10);
        controller.chestView.unlockWtime.interactable = false;
        controller.chestView.unlockWgem.interactable = false;
        UnlockthisChest();
        controller.chestView.stopACoroutine(ref controller.chestModel.CO_opening);
        controller.chestView.chestSelfButton.enabled = true;
        controller.SetChestDisplaySprite(controller.chestModel.openedImage);
        controller.SetChestTextStatus("Click to Open");
    }

    private void SpendCurrency(int _gem)
    {
        EventServices.instance.Invoke_ChestSpending(_gem);
    }

    private bool UnlockRemainingChest()
    {
        if (ChestService.instance.openingQueue[0] == controller)
        {
            ChestService.instance.openingQueue.Remove(ChestService.instance.openingQueue[0]);
            if (ChestService.instance.openingQueue.Count > 0)
            {
                ChestService.instance.openingQueue[0].chestModel.A_startChestUnlocking?.Invoke();
            }
            return true;
        }
        return false;
    }
    private void UnlockthisChest()
    {
        if (ChestService.instance.openingQueue.Count > 0 && ChestService.instance.openingQueue.Contains(controller))
        {
            if (!UnlockRemainingChest()) ChestService.instance.openingQueue.Remove(controller);
        }
    }
}
