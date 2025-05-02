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
    [SerializeField] public ItemManager itemManager;

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

    public AudioClip depositSound;
    public AudioManager audioManager;



    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        backpack = new Inventory(backpackSlotsCount);
        toolbar = new Inventory(toolbarSlotsCount);
        storage = new Inventory(storageSlotsCount);
        letterGifts = new Inventory(giftsSlotsCount);

        backpack.itemManager = itemManager;
        storage.itemManager = itemManager;
        letterGifts.itemManager = itemManager;

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


    public void OrganizeStorageByNumber()
    {
        storage.OrganizeByItemNumber();
    }

    public void StoreAllFromBackpack()
    {
        

        backpack.organizerArray = new int[80];

        for (int i = 0; i < backpackSlotsCount; i++)
        {
            if (backpack.slots[i].itemNumber < backpack.organizerArray.Length)
            {
                int q = backpack.slots[i].itemNumber;
                int p = backpack.slots[i].count;

                backpack.organizerArray[q] = backpack.organizerArray[q] + p;

                while (backpack.slots[i].count > 0)
                {
                    backpack.Remove(i);
                }
            }
        }

        for (int n = 0; n < backpack.organizerArray.Length; n++)
        {
        
            if (backpack.organizerArray[n] == 0)
            {
                continue;

            }
            else
            {
                for (int i = 0; i < backpack.organizerArray[n]; i++)
                {
                    Item toAdd = itemManager.GetItemByNumber(n);
                    storage.Add(toAdd);
                }
            }
        }

    }

}
