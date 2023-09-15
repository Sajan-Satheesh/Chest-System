using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    [field:SerializeField] public Image displayImage { get; set; }
    [field:SerializeField] public TMP_Text chestStatus { get; set; }
    [field: SerializeField] public Button chestSelfButton { get; set; }
    [field: SerializeField] public Button unlockWgem { get; set; }
    [field: SerializeField] public Button unlockWtime { get; set; }

    private ChestContoller chestContoller;

    void Start()
    {
        chestContoller.startChestView();
    }

    public void startAcoroutine(ref Coroutine coroutine, Func<float,IEnumerator> function, float time)
    {
        coroutine = StartCoroutine(function(time));
    }

    public void stopACoroutine(ref Coroutine coroutine)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
            Debug.Log("coroutine stopped");
        }
    }

    public void getChestController(ChestContoller _chestContoller)
    {
        this.chestContoller = _chestContoller;
    }

    public void startOpeningChest()
    {
        chestContoller.changeChestState(ChestState.inQueue);
    }

    public void removeChest()
    {
        chestContoller.changeChestState(ChestState.remove);
    }

    public void unlockWithGems()
    {
        chestContoller.changeChestState(ChestState.unlocked);
    }

}
