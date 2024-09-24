using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemController;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventoryScriptable", order = 1)]
public class InventoryScriptable : ScriptableObject
{
    [Header("Current Inventory")]
    public string[] foodItems;  //all food
    public int[] amounts;       //amount of each food that is in inventory
    public string[] ClothesItems;  //all clothes
    public int[] amounts2;       //amount of each clothing item that is in inventory

    [Header("All items")]
    public float currency;      //current amount of money
    public List<ItemDetails> availableItems;    //all food details
    public List<ItemDetails> availableItems2;    //all clothes details
}
