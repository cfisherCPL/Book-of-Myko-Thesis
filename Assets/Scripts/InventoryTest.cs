using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryTest
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType itemType;
        public int count;
        public int maxAllowed;

        public Slot()
        {
            itemType = CollectableType.NONE;
            count = 0;
            maxAllowed = 99;
        }

        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(CollectableType itemType)
        {
            this.itemType = itemType;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public InventoryTest(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(CollectableType typeToAdd)
    {
        foreach (Slot slot in slots)
        {
            if(slot.itemType == typeToAdd && slot.CanAddItem())
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if(slot.itemType == CollectableType.NONE)
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
    }

}
