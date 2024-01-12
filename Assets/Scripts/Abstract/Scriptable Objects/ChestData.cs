using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Chest",menuName = "Chests/Chest Type", order = 2)]
public class ChestData : ScriptableObject
{
    [SerializeField] public ChestTypes chestType;
    [SerializeField] public ChestStates spawnState;
    [SerializeField] public Sprite lockedChest;
    [SerializeField] public Sprite openedChest;
    [SerializeField] public float waitTime;
    [SerializeField, Range(100,1200)] public int minCoins, maxCoins;
    [field:SerializeField, Range(10, 100)] public int minGems { get; private set; }
    [field: SerializeField, Range(10, 100)] public int maxGems { get; private set; }
    [field:SerializeField] public ChestView chestView { get; private set; }
}

