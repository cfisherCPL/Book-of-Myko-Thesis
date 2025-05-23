using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots_UI : MonoBehaviour
{
    public int slotID;

    [SerializeField] public GameObject localInventory;
    [SerializeField] public FoundMushroomTracker unlockedMushrooms;

    public Inventory_UI localInventoryUI;
    public Inventory inventory;

    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    //[SerializeField] public GameObject dropItemButton;

    [SerializeField] private GameObject highlight;
    [SerializeField] public GameObject newItemIndicator;

    void Awake()
    {
        localInventoryUI = localInventory.GetComponent<Inventory_UI>();
    }


    public void SetItem(Inventory.Slot slot)
    {
        if(slot != null)
        {
        
            itemIcon.sprite = slot.icon;
            itemIcon.color = slot.iconColor;
            quantityText.text = slot.count.ToString();


        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
        if (newItemIndicator != null)
        {
            newItemIndicator.SetActive(false);
        }
    }

    public void SetHighlight(bool isOn)
    {
        highlight.SetActive(isOn);
    }

    public void BeingDragged()
    {
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 0.5f);
    }

    public void EndDrag()
    {
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1);
    }

}
