using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeServices : G_MonoSingleton<ExchangeServices>
{
    [SerializeField] private int coins;
    [SerializeField] private int gems;
    public Action<int, int> A_updateUI { get; set; }

    private void Start()
    {
        ChestService.instance.A_initiateReward += Reward;
        ChestService.instance.A_initiateSpend+= Spend;
        updateUI();
    }

    private void Reward(int _coins, int _gems)
    {
        coins+= _coins;
        gems += _gems;
        updateUI();
    }
    private void Spend( int _gems)
    {
        if (_gems > gems)
        {
            Debug.Log("Gems are not available");
        }
        else
        {
            gems -= _gems;
            updateUI();
        }
    }

    private void updateUI()
    {
        A_updateUI?.Invoke(coins, gems);
    }
}
