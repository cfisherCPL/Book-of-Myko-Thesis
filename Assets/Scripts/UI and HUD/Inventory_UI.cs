using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public string inventoryName;

    public List<Slots_UI> slots = new List<Slots_UI> ();

    public static Inventory_UI Instance { get; private set; }

    [SerializeField] private Canvas canvas;
    private Slots_UI draggedSlot;
    private Image draggedIcon;
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
        //inventoryPanel.SetActive(false);
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
            Debug.Log("LeftShift Held");
        }
        else
        {
            dragSingle = false;
        }

        //adding this to Update fixes the inventory panel not updating unless toggle
        //but seems non permormant. we shouldnt have to check EVERY frame
        //to see if an item was added or not 1-18-25
        Refresh();
    }


    public void ToggleInventory()
    {
        //adding this if surround seems to prevent the inventory panel 
        //(not the toolbar) from updating as normal unless it is toggled 1-18-25 cvf
      if (inventoryPanel != null)
        { 
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                Refresh();
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }
    }



    public void Refresh()
    {
        if(slots.Count == inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.slots[i]);
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
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(inventory.slots[draggedSlot.slotID].itemName);

        if (itemToDrop != null)
        {
            if (dragSingle)
            {
                GameManager.instance.player.DropItem(itemToDrop);
                inventory.Remove(draggedSlot.slotID);
            }
            else 
            {
                GameManager.instance.player.DropItem(itemToDrop, inventory.slots[draggedSlot.slotID].count);
                inventory.Remove(draggedSlot.slotID, inventory.slots[draggedSlot.slotID].count);
            }
            
            Refresh();
        }
       
        draggedSlot = null;
    }

    public void SlotBeginDrag(Slots_UI slot)
    {
        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false;
        draggedIcon.rectTransform.sizeDelta = new Vector2(50, 50);

        MoveToMousePosition(draggedIcon.gameObject);

        Debug.Log("Start Drag: " + draggedSlot.name);

    }

    public void SlotDrag()
    {
        MoveToMousePosition(draggedIcon.gameObject);

        Debug.Log("Dragging: " + draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Destroy(draggedIcon.gameObject);
        draggedIcon = null;



        //thwos nullRef exception 1-15-25
        //Debug.Log("Done Dragging: " + draggedSlot.name);
    }

    public void SlotDrop(Slots_UI slot)
    {
        Debug.Log("Dropped: " + draggedSlot.name + " on " + slot.name);
        draggedSlot.inventory.MoveSlot(draggedSlot.slotID, slot.slotID);
        Refresh();
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
