using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiServices : G_MonoSingleton<UiServices>
{
    [SerializeField] private TMP_Text T_coins;
    [SerializeField] private TMP_Text T_gems;

    private void Start()
    {
        ExchangeServices.instance.A_updateUI += updateCoinsAndGems;
    }

    private void updateCoinsAndGems(int _coins, int _gems)
    {
        T_coins.text = _coins.ToString();
        T_gems.text = _gems.ToString();
    }
}
