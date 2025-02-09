using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private FoundMushroomTracker unlockedMushrooms;

    public string inventoryName;

    public List<Slots_UI> slots = new List<Slots_UI> ();

    public static Inventory_UI Instance { get; private set; }

    [SerializeField] private Canvas canvas;
    
    private bool dragSingle;

    private Inventory inventory;

    private void Awake()
    {

        canvas = FindObjectOfType<Canvas>();
   
    }

    private void Start()
    {
        
        inventory = GameManager.instance.player.inventory.GetInventoryByName(inventoryName); 
        SetupSlots();
        Refresh();
        
    }
   


    public void Refresh()
    {
        //2-3-35 suddenly throwing null ref error at startup
        //error was NOT present at save and quit prior evening
        if (slots.Count == inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.slots[i]);
                    
                    
                    int thisItemNum = 0;
                    thisItemNum = inventory.slots[i].itemNumber;
                    //Debug.Log("The Length of the MushCheckList is: " + unlockedMushrooms.mushroomByItemNumber.Count);
                    //Debug.Log("Passed Item Number was: " + thisItemNum);

                    if (thisItemNum < unlockedMushrooms.mushroomByItemNumber.Count && !unlockedMushrooms.mushroomByItemNumber[thisItemNum])
                    {
                        slots[i].newItemIndicator.SetActive(true);
                    }
                    
                    if (unlockedMushrooms.mushroomByItemNumber[thisItemNum])
                    {
                        slots[i].newItemIndicator.SetActive(false);
                    }
                    
                 
                }
                else
                {
                    slots[i].SetEmpty();

                }
            }
        }
   
    }

    public void Remove()
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(
            inventory.slots[UI_Manager.draggedSlot.slotID].itemName);

        if (itemToDrop != null)
        {
            if (UI_Manager.dragSingle)
            {
                GameManager.instance.player.DropItem(itemToDrop);
                inventory.Remove(UI_Manager.draggedSlot.slotID);
            }
            else 
            {
                GameManager.instance.player.DropItem(itemToDrop, inventory.slots[UI_Manager.draggedSlot.slotID].count);
                inventory.Remove(UI_Manager.draggedSlot.slotID, inventory.slots[UI_Manager.draggedSlot.slotID].count);
            }
            
            Refresh();
        }
       
        UI_Manager.draggedSlot = null;
    }

    public void SlotBeginDrag(Slots_UI slot)
    {
        UI_Manager.draggedSlot = slot;
        UI_Manager.draggedIcon = Instantiate(UI_Manager.draggedSlot.itemIcon);
        UI_Manager.draggedIcon.transform.SetParent(canvas.transform);
        UI_Manager.draggedIcon.raycastTarget = false;
        UI_Manager.draggedIcon.rectTransform.sizeDelta = new Vector2(50, 50); //not sure this does anything 1-19-25

 

        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);

        Debug.Log("Start Drag: " + UI_Manager.draggedSlot.name);

    }

    public void SlotDrag()
    {
        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);

        //Debug.Log("Dragging: " + UI_Manager.draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Destroy(UI_Manager.draggedIcon.gameObject);
        UI_Manager.draggedIcon = null;
        Debug.Log("End drag.");

    }

    public void SlotDrop(Slots_UI slot)
    {
        if (UI_Manager.dragSingle)
        {
            Debug.Log("Dragged Slot: " + UI_Manager.draggedSlot.name);
            Debug.Log("Dragged Slot Inventory: " + UI_Manager.draggedSlot.inventory);

            Debug.Log("Dropped Slot: " + slot.name);
            Debug.Log("Dropped Slot Inventory: " + slot.inventory);

            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID, slot.slotID, slot.inventory);
        }
        else
        {
            Debug.Log("Dragged Slot: " + UI_Manager.draggedSlot.name);
            Debug.Log("Dragged Slot Inventory: " + UI_Manager.draggedSlot.inventory);

            Debug.Log("Dropped Slot: " + slot.name);
            Debug.Log("Dropped Slot Inventory: " + slot.inventory);
            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID, slot.slotID, slot.inventory, 
                UI_Manager.draggedSlot.inventory.slots[UI_Manager.draggedSlot.slotID].count);
        }

        GameManager.instance.uiManager.RefreshAll();
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if (canvas != null)
        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);

            toMove.transform.position = canvas.transform.TransformPoint(position);

        }
    }

    private void SetupSlots()
    {
        int counter = 0;

        foreach (Slots_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
            slot.inventory = inventory;
        }
    }
}
