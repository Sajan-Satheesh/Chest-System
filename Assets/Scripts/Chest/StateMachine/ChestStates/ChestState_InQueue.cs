using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestState_InQueue : ChestState
{
    public ChestState_InQueue(ChestController _chestControlller) : base(_chestControlller ,ChestStates.IN_QUEUE)
    {
    }

    //public override ChestStates thisChestState { get => thisChestState; protected set => thisChestState = ChestStates.inQueue; }

    public override void OnEnter()
    {
        QueueChest();
        updateState = true;
    }

    private void QueueChest()
    {
        List<ChestController> toOpenQueue = ChestService.instance.openingQueue;
        if (toOpenQueue.Count == 0)
        {
            AddToQueue();
            controller.chestModel.chestStateMachine.SetState(ChestStates.UNLOCKING);
        }
        else if (toOpenQueue.Count < ChestService.instance.unlockingQueueSize)
        {
            AddToQueue();
        }
        else
        {
            Debug.Log("Queue to unlock is full");
            controller.chestModel.chestStateMachine.SetState(ChestStates.LOCKED);
        }
    }
    private void AddToQueue()
    {
        ChestService.instance.openingQueue.Add(controller);
        controller.chestView.unlockWtime.interactable = false;
        controller.SetChestTextStatus("Queued");
    }
}
