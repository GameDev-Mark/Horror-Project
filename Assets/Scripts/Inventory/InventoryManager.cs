using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<string> inventoryItems = new List<string>();

    private void Start()
    {
        AddItemToInventory(("Torch"));
        AddItemToInventory(("SaltGun"));
        //Debug.Log($"gameobjects : {inventoryItems[0]} // + {inventoryItems[1]}");
    }

    // pick up trigger // add item to inventory
    public void AddItemToInventory(string itemNameGO)
    {
        inventoryItems.Add(itemNameGO);
        //inventoryItems.ForEach(Print);
    }

    private void Print(string s)
    {
        
    }

    // access inventory items
    public List<string> InventoryItems()
    {
        return inventoryItems;
    }
}