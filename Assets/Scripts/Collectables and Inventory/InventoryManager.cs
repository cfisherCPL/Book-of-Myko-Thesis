using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    /*InventoryManager exists to handle the use of 
     * multiple inventorys on a player or in the game
     * such as the backback, collection box, and display case
     * 1-18-25
     * */
    
    public Dictionary<string, Inventory> inventoryByName = new Dictionary<string, Inventory>();
    
    [Header("Backpack")]
    public Inventory backpack;
    public int backpackSlotsCount;

    [Header("Toolbar")]
    public Inventory toolbar;
    public int toolbarSlotsCount;

    [Header("Storage")]
    public Inventory storage;
    public int storageSlotsCount;

    [Header("LetterGifts")]
    public Inventory letterGifts;
    public int giftsSlotsCount;



    private void Awake()
    {
        backpack = new Inventory(backpackSlotsCount);
        toolbar = new Inventory(toolbarSlotsCount);
        storage = new Inventory(storageSlotsCount);
        letterGifts = new Inventory(giftsSlotsCount);

        inventoryByName.Add("Backpack", backpack);
        inventoryByName.Add("Toolbar", toolbar);
        inventoryByName.Add("Storage", storage);
        inventoryByName.Add("LetterGifts", letterGifts);

    }

    //this Add() is where it is checking which inventory an item should go to?
    public void Add(string inventoryName, Item item)
    {
        if (inventoryByName.ContainsKey(inventoryName))
        {
            inventoryByName[inventoryName].Add(item);
            Debug.Log("Item sent to " +inventoryName);
        }
    }

    public Inventory GetInventoryByName(string inventoryName)
    {
        if (inventoryByName.ContainsKey(inventoryName)) return inventoryByName[inventoryName];
        return null;
    }


    public void ResetInventories()
    {
        for (int i = 0; i < backpackSlotsCount; i++)
        {
            while (backpack.slots[i].count > 0)
            {
                backpack.Remove(i);
            }
        }

        for (int i = 0; i < storageSlotsCount; i++)
        {
            while (storage.slots[i].count > 0)
            {
                storage.Remove(i);
            }
        }

        for (int i = 0; i < giftsSlotsCount; i++)
        {
            while (letterGifts.slots[i].count > 0)
            {
                letterGifts.Remove(i);
            }
        }

    }

}
