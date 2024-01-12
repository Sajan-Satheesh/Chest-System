
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingletonGeneric<ChestService>
{
    [SerializeField] private int totalChests;
    [SerializeField] public int unlockingQueueSize;
    [SerializeField] public List<ChestController> openingQueue { get; private set; } = new List<ChestController>();
    [SerializeField] public List<ChestController> allChests = new List<ChestController>();
    [SerializeField] Transform parentOfChests;
    [SerializeField] ChestCollectionData chestCollection;//JFT


    private void Start()
    {
        CreateChests();
        CheckQueuesize();
    }

    private void CheckQueuesize()
    {
        if(totalChests < unlockingQueueSize)
        {
            unlockingQueueSize= totalChests;
        }
    }


    public void CreateChests()
    {    
        if(allChests.Count < totalChests)
        {
            int existingChestCount = allChests.Count;
            for (int i = 0; i < totalChests - existingChestCount; i++)
            {
                allChests.Add(new ChestController(DrawRandomChest(), parentOfChests)); // JFT
            }
        }
        else
        {
            Debug.Log("Slots are Full");
        }
    
    }

    private ChestData DrawRandomChest()
    {
        int index = UnityEngine.Random.Range(0, chestCollection.chestCollection.Count);
        return chestCollection.chestCollection[index];
    }
}


