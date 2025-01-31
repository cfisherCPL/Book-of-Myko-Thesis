using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class StorageContainer : MonoBehaviour
{
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private GameObject storageInventoryUI;
    [SerializeField] private UI_Manager uiManager;

    private bool inRange = false;


    private void Awake()
    {
        popupText.gameObject.SetActive(false);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Storage Trigger");

        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerIsTrigger player))
        {
            popupText.gameObject.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited Storage Trigger");
        storageInventoryUI.SetActive(false);
        popupText.gameObject.SetActive(false);
        inRange = false;
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown("e"))
        {
            TogglePanelUI();
            if(!uiManager.inventoryPanel.activeSelf)
            {
                uiManager.ToggleInventory(); //turn on/off the backpack at the same time
            }
            
        }
    }


    void TogglePanelUI()
    {
        if (storageInventoryUI != null)
        {
            if (!storageInventoryUI.activeSelf)
            {
                storageInventoryUI.SetActive(true);
                uiManager.RefreshInventoryUI("Storage");
            }
            else
            {
                storageInventoryUI.SetActive(false);
            }
        }
    }
}
