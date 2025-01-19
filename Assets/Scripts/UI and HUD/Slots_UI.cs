using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots_UI : MonoBehaviour
{
    public int slotID;

    [SerializeField] public GameObject localInventory;
    public Inventory_UI localInventoryUI;
    public Inventory inventory;

    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    //[SerializeField] public GameObject dropItemButton;

    [SerializeField] private GameObject highlight;

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
    }

    public void SetHighlight(bool isOn)
    {
        highlight.SetActive(isOn);
    }

}
