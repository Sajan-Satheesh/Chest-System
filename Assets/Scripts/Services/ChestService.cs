
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : G_MonoSingleton<ChestService>
{
    [SerializeField] private int totalChests;
    [SerializeField] public int unlockingQueueSize;
    [SerializeField] public List<Action> Q_ToOpen = new List<Action>();
    [SerializeField] public List<ChestContoller> allChests = new List<ChestContoller>();
    [SerializeField] Transform parentOfChests;
    [SerializeField] ChestSOC chestCollection;//JFT

    public Action<int, int> A_initiateReward { get; set; }
    public Action<int> A_initiateSpend { get; set; }

    private void Start()
    {
        createChests();
        checkQueuesize();
    }

    private void checkQueuesize()
    {
        if(totalChests < unlockingQueueSize)
        {
            unlockingQueueSize= totalChests;
        }
    }


    public void createChests()
    {    
        if(allChests.Count < totalChests)
        {
            int existingChestCount = allChests.Count;
            for (int i = 0; i < totalChests - existingChestCount; i++)
            {
                allChests.Add(new ChestContoller(drawRandomChest(), parentOfChests)); // JFT
            }
        }
        else
        {
            Debug.Log("Slots are Full");
        }
    
    }

    private ChestSO drawRandomChest()
    {
        int index = UnityEngine.Random.Range(0, chestCollection.chestCollection.Count);
        return chestCollection.chestCollection[index];
    }
}

public enum ChestTypes { common, rare, epic, legendary}

public enum ChestState { locked, unlocked, unlocking, inQueue, remove }
