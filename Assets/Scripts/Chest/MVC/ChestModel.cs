
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestModel
{
    public int minCoins { get; private set; }
    public int maxCoins { get; private set; }
    public int minGems { get; private set; }
    public int maxGems { get; private set; }
    public ChestStates spawnState { get; set; }
    public ChestTypes chestType { get; private set; }
    public float openingTime { get; private set; }
    public Sprite lockedImage { get; private set; }
    public Sprite openedImage { get; private set; }
    public Coroutine CO_opening = null;
    public ChestStateMachine chestStateMachine { get; private set; }
    public Action A_startChestUnlocking;
    public ChestModel(ChestData chestData, ChestController chestController) 
    {
        minCoins = chestData.minCoins;
        maxCoins = chestData.maxCoins;
        minGems= chestData.minGems;
        maxGems = chestData.maxGems;
        openingTime = chestData.waitTime;
        spawnState = chestData.spawnState;
        chestType = chestData.chestType;
        lockedImage = chestData.lockedChest;
        openedImage = chestData.openedChest;
        chestStateMachine = new ChestStateMachine(chestController);
    }
}
