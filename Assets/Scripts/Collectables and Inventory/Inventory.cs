using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class Inventory
{
    //[SerializeField] public Inventory_UI inventory_UI;

    [SerializeField] public int numSlotsOpen;

    
    [System.Serializable]    
    public class Slot
    {
        public string itemName;
        public int itemNumber;
        public int count;
        public int maxAllowed;

        public Sprite icon;
        public Color iconColor;

        public Slot()
        {
            itemName = "";
            itemNumber = 0;
            count = 0;
            maxAllowed = 9;
        }

        public bool IsEmpty
        {
            get
            {
                if(itemName == "" && count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CanAddItem(string itemName)
        {
            if(this.itemName == itemName && count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.itemNumber = item.data.itemNumber;
            this.icon = item.data.icon;
            this.iconColor = item.data.iconColor;
            count++;

        }

        public void AddItem(string itemName, int itemNum, Sprite icon, int maxAllowed, Color iconColor)
        {
            this.itemName = itemName;
            this.itemNumber = itemNum;
            this.icon = icon;
            this.iconColor =iconColor;
            count++;
            this.maxAllowed = maxAllowed;

        }



        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if (count ==0)
                {
                    icon = null;
                    itemName = "";
                    itemNumber = 0;
                  
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    /*Instantiates the slots list
     * with the number of slots defined
     * in PlayerIsTrigger
    */
    public Inventory(int numSlots)
    {
        numSlotsOpen = 0;
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
            numSlotsOpen++;
        }
    }

    public void Add(Item item)
    {
        foreach (Slot slot in slots)
        {
            if(slot.itemName == item.data.itemName && slot.CanAddItem(item.data.itemName))
            {
                slot.AddItem(item);
                //inventory_UI.Refresh();
                UnityEngine.Debug.Log("Item added to existing group.");
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.AddItem(item);
                //inventory_UI.Refresh();
                numSlotsOpen--;
                UnityEngine.Debug.Log("Item added to new slot.");
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.itemName == "")
            {
                numSlotsOpen++;
                UnityEngine.Debug.Log("Open Slot Found.");
            }
        }

    }
    
    public bool ItemCanBeSlotted(Item item)
    {
        bool slotAvailable = false;
        
        foreach (Slot slot in slots)
        {
            if (slot.itemName == item.data.itemName && slot.CanAddItem(item.data.itemName))
            {
                slotAvailable = true;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.itemName == "")
            {
                slotAvailable = true;
            }
        }

        return slotAvailable;
    }

    public void Remove (int index)
    {
        slots[index].RemoveItem();

        numSlotsOpen = 0;
        foreach (Slot slot in slots)
        {
            
            if (slot.itemName == "")
            {
                numSlotsOpen++;
            }
        }

    }

    public void Remove(int index, int numToRemove)
    {
        if (slots[index].count >= numToRemove)
        {
            for (int i = 0; i < numToRemove; i++) 
            {
                Remove(index);
            }
        }
    }

    public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory, int numToMove = 1)
    {
        Slot fromSlot = slots[fromIndex];
        Slot toSlot = toInventory.slots[toIndex];

        if (toSlot.IsEmpty || toSlot.CanAddItem(fromSlot.itemName))
        {
            for (int i = 0; i < numToMove; i++)
            {
                toSlot.AddItem(fromSlot.itemName, fromSlot.itemNumber, fromSlot.icon, fromSlot.maxAllowed, fromSlot.iconColor);
                fromSlot.RemoveItem(); 
            }
        }
    }
}
