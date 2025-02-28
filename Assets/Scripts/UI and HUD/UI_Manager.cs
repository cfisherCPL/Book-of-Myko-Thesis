using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI> ();
   
    public List<Inventory_UI> inventoryUIs;

    public static Slots_UI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;
    public GameObject inventoryPanel;
    public GameObject storagePanel;
    public GameObject toolbarPanel;
    public GameObject journalPanel;
    public GameObject letterReqPanel;

  
    public void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        Invoke("HidePanels", 0.001f);
        
    }

    private void HidePanels()
    {
        //making this it's own thing to be able to Invoke after micro delay
        inventoryPanel.SetActive (false);
        storagePanel.SetActive(false);
        journalPanel.SetActive(false);
        /*
         * right now the toolbar is useful but not used
         * removing it entirely requires updating gameobjects AND inventory scripts
         * just hide it until its needed as a mechanic 
         * 30 jan 2025 CVF (sorry future me)
         */
        toolbarPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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

        //Inventories should always be updated and active, even if non-performant 1-18-25
        //so sayeth the command of "getting this shit done"
        //2-3-25 this is working, but it is a problem to debug when it calls as fast as it does
        //2-16-25 only run refresh all if the panel is actually active. dur.
        if (inventoryPanel.activeSelf |  storagePanel.activeSelf)
        {
            RefreshAll();
        }
        
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
                RefreshInventoryUI("Backpack");
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }
    }

    public void RefreshInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    }

    public void RefreshAll()
    {
        foreach (KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIByName) 
        {
            keyValuePair.Value.Refresh();
        }
    }


    public Inventory_UI GetInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }

        Debug.LogWarning("There is not inventory ui for " + inventoryName);
        return null;
    }

    void Initialize()
    {
        foreach (Inventory_UI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }

    public void RemoveDragged()
    {
        draggedSlot.localInventoryUI.Remove();
    }
}
