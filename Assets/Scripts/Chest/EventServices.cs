using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventServices : MonoSingletonGeneric<EventServices>
{
    public Action<int, int> chest_initiateReward;
    public Action<int> chest_initiateSpend;
    public Action<int, int> currency_UpdateUI;

    public void Invoke_ChestReward(int reward, int amount)
    {
        chest_initiateReward?.Invoke(reward, amount);
    }

    public void Invoke_ChestSpending(int amount)
    {
        chest_initiateSpend?.Invoke(amount);
    }

    public void Invoke_CurrencyUpdateUI(int coins, int gems)
    {
        currency_UpdateUI?.Invoke(coins, gems);
    }

}
