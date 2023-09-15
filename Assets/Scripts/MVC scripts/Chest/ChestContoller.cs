using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestContoller 
{
    private ChestModel chestModel;
    private ChestView chestView;

    public ChestContoller(ChestSO chestSO, Transform parentTransform)
    {

        chestModel = new ChestModel(chestSO);
        chestView = GameObject.Instantiate(chestSO.chestView, parentTransform);
        chestModel.A_startChestUnlocking = startUnlocking;
        chestView.getChestController(this);
        
    }

    public void startChestView()
    {
        changeChestState(ChestState.locked);
    }
    public void changeChestState(ChestState _state)
    {
        chestModel.chestState = _state;
        updateAsPerState();
    }

    private void updateAsPerState()
    {
        switch (chestModel.chestState)
        {
            case ChestState.locked:
                lockChest();
                break;
            case ChestState.unlocked:
                unlockChest();
                break;
            case ChestState.unlocking:
                startUnlocking();
                break;
            case ChestState.inQueue:
                queueChest();
                break;
            case ChestState.remove:
                remove();
                break;
            default:
                break;
        }
    }

    #region state functions
    private void lockChest()
    {
        setChestDisplaySprite(chestModel.lockedImage);
        chestView.chestSelfButton.enabled = false;
        setChestTextStatus("Chest Locked");
    }

    private void startUnlocking()
    {
        runCountdown();
    }
    
    public void queueChest()
    {
        if (chestModel.chestState != ChestState.inQueue) { return; }

        List<Action> mainQ = ChestService.instance.Q_ToOpen;
        if (mainQ.Count == 0)
        {
            addToQueue();
            changeChestState(ChestState.unlocking);
        }
        else if (mainQ.Count < ChestService.instance.unlockingQueueSize)
        {
            addToQueue();
        }
        else
        {
            Debug.Log("Queue to unlock is full");
        }
    }

    private void unlockChest()
    {
        spendExchangeable(10);
        chestView.unlockWtime.interactable = false;
        chestView.unlockWgem.interactable = false;
        unlockthisChest();
        chestView.stopACoroutine(ref chestModel.CO_opening);
        chestView.chestSelfButton.enabled = true;
        setChestDisplaySprite(chestModel.openedImage);
        setChestTextStatus("Click to Open");
    }

    private void remove()
    {
        removeThisChest();
    }
    #endregion

    #region remove extras
    private int generateCoinReward()
    {
        return generateRandomReward(chestModel.minCoins, chestModel.maxCoins);
    }

    private int generateGemReward()
    {
        return generateRandomReward(chestModel.minGems, chestModel.maxGems);
    }

    private int generateRandomReward(int _min, int _max)
    {
        return UnityEngine.Random.Range(_min, _max);
    }
    private void getRewards()
    {
        ChestService.instance.A_initiateReward?.Invoke(generateCoinReward(), generateGemReward());
    }
    private void removeThisChest()
    {
        getRewards();
        if (chestModel.chestState != ChestState.remove) { return; }

        ChestService.instance.allChests.Remove(this);

        GameObject.Destroy(chestView.gameObject);
        chestModel = null;
    }
    #endregion

    #region unlocking extras
    private void runCountdown()
    {
        if (chestModel.CO_opening != null)
        {
            chestView.stopACoroutine(ref chestModel.CO_opening);
        }
        chestView.startAcoroutine(ref chestModel.CO_opening, runWaitingTime, chestModel.openingTime);
    }

    private IEnumerator runWaitingTime(float hours)
    {
        float minutes = hours * 60;
        float seconds = 0f;
        do
        {
            updateTimerText(minutes, seconds);
            yield return new WaitForSeconds(1f);
            seconds--;
            if (seconds <= 0) { minutes--; seconds = 60; }

        } while (minutes >= 0);
        changeChestState(ChestState.unlocked);
    }
    #endregion

    #region unlock extras
    private void spendExchangeable(int _gem)
    {
        ChestService.instance.A_initiateSpend?.Invoke(10);
    }

    private bool unlockRemainingChest()
    {
        if (ChestService.instance.Q_ToOpen[0] == chestModel.A_startChestUnlocking)
        {
            ChestService.instance.Q_ToOpen.Remove(ChestService.instance.Q_ToOpen[0]);
            if (ChestService.instance.Q_ToOpen.Count > 0)
            {
                ChestService.instance.Q_ToOpen[0]?.Invoke();
            }
            return true;
        }
        return false;
    }
    private void unlockthisChest()
    {
        if (ChestService.instance.Q_ToOpen.Count > 0 && ChestService.instance.Q_ToOpen.Contains(chestModel.A_startChestUnlocking))
        {
            if (!unlockRemainingChest()) ChestService.instance.Q_ToOpen.Remove(chestModel.A_startChestUnlocking);
        }
    }
    #endregion

    #region queuing extras
    private void addToQueue()
    {
        ChestService.instance.Q_ToOpen.Add(chestModel.A_startChestUnlocking);
        chestView.unlockWtime.interactable = false;
        setChestTextStatus("Queued");
    }
    #endregion

    #region common extras
    private void updateTimerText(float mins, float secs)
    {
        setChestTextStatus($"wait for {(int)mins} mins {(int)secs} secs.");
    }

    private void setChestTextStatus(string _text)
    {
        chestView.chestStatus.text = _text;
    }
    private void setChestDisplaySprite(Sprite _sprite)
    {
        chestView.displayImage.sprite = _sprite;
    }
    #endregion

}