using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class InventoryTest
{
    [SerializeField] public Inventory_UI inventory_UI;

    [SerializeField] public int numSlotsOpen;

    
    [System.Serializable]    
    public class Slot
    {
        public CollectableType itemType;
        public int count;
        public int maxAllowed;

        public Sprite icon;
        public Color iconColor;

        public Slot()
        {
            itemType = CollectableType.NONE;
            count = 0;
            maxAllowed = 9;
        }

        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(PickupItem item)
        {
            this.itemType = item.itemType;
            this.icon = item.icon;
            this.iconColor = item.iconColor;
            count++;

        }

        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if (count ==0)
                {
                    icon = null;
                    itemType = CollectableType.NONE;
                  
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    /*Instantiates the slots list
     * with the number of slots defined
     * in PlayerIsTrigger
    */
    public InventoryTest(int numSlots)
    {
        numSlotsOpen = 0;
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
            numSlotsOpen++;
        }

      

    }

    public void Add(PickupItem item)
    {
        foreach (Slot slot in slots)
        {
            if(slot.itemType == item.itemType && slot.CanAddItem())
            {
                slot.AddItem(item);
                inventory_UI.Refresh();
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if(slot.itemType == CollectableType.NONE)
            {
                slot.AddItem(item);
                inventory_UI.Refresh();
                numSlotsOpen--;
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.itemType == CollectableType.NONE)
            {
                numSlotsOpen++;
            }
        }

    }
    

    public void Remove (int index)
    {
        slots[index].RemoveItem();

        numSlotsOpen = 0;
        foreach (Slot slot in slots)
        {
            
            if (slot.itemType == CollectableType.NONE)
            {
                numSlotsOpen++;
            }
        }

    }

}
