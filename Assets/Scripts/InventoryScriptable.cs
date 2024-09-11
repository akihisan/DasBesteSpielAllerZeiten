using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventoryScriptable", order = 1)]
public class InventoryScriptable : ScriptableObject
{
    public string[] foodItems;
    public int[] amounts;
}
