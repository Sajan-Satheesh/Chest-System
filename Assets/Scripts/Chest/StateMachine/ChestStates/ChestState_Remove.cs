using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestState_Remove : ChestState
{
    public ChestState_Remove(ChestController _chestControlller) : base(_chestControlller, ChestStates.REMOVE)
    {
    }

    //public override ChestStates thisChestState { get => thisChestState; protected set => thisChestState = ChestStates.remove; }

    public override void OnEnter()
    {
        Remove();
        updateState = true;
    }
    private void Remove()
    {
        RemoveThisChest();
    }
    private int GenerateCoinReward()
    {
        return GenerateRandomReward(controller.chestModel.minCoins, controller.chestModel.maxCoins);
    }

    private int GenerateGemReward()
    {
        return GenerateRandomReward(controller.chestModel.minGems, controller.chestModel.maxGems);
    }

    private int GenerateRandomReward(int _min, int _max)
    {
        return Random.Range(_min, _max);
    }
    private void GetRewards()
    {
        EventServices.instance.Invoke_ChestReward(GenerateCoinReward(), GenerateGemReward());
    }
    private void RemoveThisChest()
    {
        GetRewards();
        ChestService.instance.allChests.Remove(controller);
        Object.Destroy(controller.chestView.gameObject);
    }

}
