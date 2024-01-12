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

    private ChestController chestContoller;

    void Start()
    {
        chestContoller.StartChestView();
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

    public void getChestController(ChestController _chestContoller)
    {
        this.chestContoller = _chestContoller;
    }

    public void startOpeningChest()
    {
        chestContoller.chestModel.chestStateMachine.SetState(ChestStates.IN_QUEUE);
    }

    public void removeChest()
    {
        chestContoller.chestModel.chestStateMachine.SetState(ChestStates.REMOVE);
    }

    public void unlockWithGems()
    {
        chestContoller.chestModel.chestStateMachine.SetState(ChestStates.UNLOCKED);
    }

}
