using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestState_UnLocking : ChestState
{
    public ChestState_UnLocking(ChestController _chestControlller) : base(_chestControlller, ChestStates.UNLOCKING)
    {
        controller.chestModel.A_startChestUnlocking = StartUnlocking;
    }

    //public override ChestStates thisChestState { get => thisChestState; protected set => thisChestState = ChestStates.unlocking; }

    public override void OnEnter()
    {
        StartUnlocking();
        updateState = true;
    }

    private void StartUnlocking()
    {
        RunCountdown();
    }

    private void RunCountdown()
    {
        if (controller.chestModel.CO_opening != null)
        {
            controller.chestView.stopACoroutine(ref controller.chestModel.CO_opening);
        }
        controller.chestView.startAcoroutine(ref controller.chestModel.CO_opening, RunWaitingTime, controller.chestModel.openingTime);
    }

    private IEnumerator RunWaitingTime(float hours)
    {
        float minutes = hours * 60;
        float seconds = 0f;
        do
        {
            controller.UpdateTimerText(minutes, seconds);
            yield return new WaitForSeconds(1f);
            seconds--;
            if (seconds <= 0) { minutes--; seconds = 60; }

        } while (minutes >= 0);
        controller.chestModel.chestStateMachine.SetState(ChestStates.UNLOCKED);
    }
}
