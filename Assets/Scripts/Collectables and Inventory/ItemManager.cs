using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> nameToItemDict = 
        new Dictionary<string, Item>();

    private Dictionary<int, Item> numberToItemDict =
        new Dictionary<int, Item>();


    private void Awake()
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }

    private void AddItem(Item item)
    {
        if (!nameToItemDict.ContainsKey(item.data.itemName))
        {
            nameToItemDict.Add(item.data.itemName, item);
        }

        if (!numberToItemDict.ContainsKey(item.data.itemNumber))
        {
            numberToItemDict.Add(item.data.itemNumber, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if (nameToItemDict.ContainsKey(key))
        {
            return nameToItemDict[key];
        }
        else
        {
            return null;
        }

    }


    public Item GetItemByNumber(int key)
    {
        if (numberToItemDict.ContainsKey(key))
        {
            return numberToItemDict[key];
        }
        else
        {
            return null;
        }
    }


}
