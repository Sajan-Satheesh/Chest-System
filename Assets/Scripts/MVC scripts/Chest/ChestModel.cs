
using System;
using UnityEngine;
using UnityEngine.UI;

public class ChestModel
{
    public int minCoins { get; private set; }
    public int maxCoins { get; private set; }
    public int minGems { get; private set; }
    public int maxGems { get; private set; }
    public ChestState chestState { get; set; }
    public ChestTypes chestType { get; private set; }
    public float openingTime { get; private set; }
    public Sprite lockedImage { get; private set; }
    public Sprite openedImage { get; private set; }
    public Coroutine CO_opening = null;
    public Action A_startChestUnlocking;
    public ChestModel(ChestSO chestSO) 
    {
        minCoins = chestSO.minCoins;
        maxCoins = chestSO.maxCoins;
        minGems= chestSO.minGems;
        maxGems = chestSO.maxGems;
        openingTime = chestSO.waitTime;
        chestState = chestSO.spawnState;
        chestType = chestSO.chestType;
        lockedImage = chestSO.lockedChest;
        openedImage = chestSO.openedChest;
    }
}
