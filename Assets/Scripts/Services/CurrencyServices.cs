using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyServices : MonoSingletonGeneric<CurrencyServices>
{
    [SerializeField] private int coins;
    [SerializeField] private int gems;
    

    private void Start()
    {
        EventServices.instance.chest_initiateReward += Reward;
        EventServices.instance.chest_initiateSpend += Spend;
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
        EventServices.instance.Invoke_CurrencyUpdateUI(coins, gems);
    }
}
