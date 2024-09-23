using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemController;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventoryScriptable", order = 1)]
public class InventoryScriptable : ScriptableObject
{
    public string[] foodItems;  //all food
    public int[] amounts;       //amount of each food that is in inventory
    public float currency;      //current amount of money
    public List<ItemDetails> availableItems;    //all clothes
}
