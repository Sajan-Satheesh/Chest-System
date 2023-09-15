using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "Chests/Chest Collection", order = 2)]
public class ChestSOC : ScriptableObject
{
    public List<ChestSO> chestCollection= new List<ChestSO>();
}