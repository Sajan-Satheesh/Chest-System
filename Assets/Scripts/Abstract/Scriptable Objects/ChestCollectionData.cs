using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "Chests/Chest Collection", order = 2)]
public class ChestCollectionData : ScriptableObject
{
    public List<ChestData> chestCollection= new List<ChestData>();
}