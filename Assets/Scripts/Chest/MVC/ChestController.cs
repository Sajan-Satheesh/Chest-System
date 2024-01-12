using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController 
{
    public ChestModel chestModel { get; private set; }
    public ChestView chestView { get; private set; }

    public ChestController(ChestData chestData, Transform parentTransform)
    {

        chestModel = new ChestModel(chestData,this);
        chestView = GameObject.Instantiate(chestData.chestView, parentTransform);
        chestView.getChestController(this);
    }

    public void StartChestView()
    {
        chestModel.chestStateMachine.InitializeState(chestModel.spawnState);
    }

    #region common extras
    public void UpdateTimerText(float mins, float secs)
    {
        SetChestTextStatus($"wait for {(int)mins} mins {(int)secs} secs.");
    }

    public void SetChestTextStatus(string _text)
    {
        chestView.chestStatus.text = _text;
    }
    public void SetChestDisplaySprite(Sprite _sprite)
    {
        chestView.displayImage.sprite = _sprite;
    }
    #endregion

}