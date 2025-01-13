using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public PickupItem[] collectableItems;

    private Dictionary<CollectableType, PickupItem> collectableItemsDict = 
        new Dictionary<CollectableType, PickupItem>();

    private void Awake()
    {
        foreach (PickupItem item in collectableItems)
        {
            AddItem(item);
        }
    }

    private void AddItem(PickupItem item)
    {
        if (!collectableItemsDict.ContainsKey(item.itemType))
        {
            collectableItemsDict.Add(item.itemType, item);
        }
    }

    public PickupItem GetItemByType(CollectableType type)
    {
        if (collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }
        else
        {
            return null;
        }

    }
}
