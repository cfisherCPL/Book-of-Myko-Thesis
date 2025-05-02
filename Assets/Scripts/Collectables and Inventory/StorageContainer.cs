using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class StorageContainer : MonoBehaviour
{
    [SerializeField] private GameObject popupText;
    [SerializeField] private GameObject storageInventoryUI;
    [SerializeField] private UI_Manager uiManager;

    [SerializeField] public GameObject depositAllButton;

    [SerializeField] public AudioClip openSound;
    [SerializeField] public AudioClip closeSound;
    
    private bool inRange = false;

    AudioManager audioManager;

    private void Awake()
    {
        popupText.gameObject.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        inRange = false;
        Debug.Log("Exited Storage Trigger");
        popupText.gameObject.SetActive(false);
        if (storageInventoryUI.activeSelf)
        {
            storageInventoryUI.SetActive(false);
        }
        if (uiManager.inventoryPanel.activeSelf)
        {
            uiManager.inventoryPanel.SetActive(false);
        }
        
        
        
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


    public void TogglePanelUI()
    {
        if (storageInventoryUI != null)
        {
            if (!storageInventoryUI.activeSelf)
            {
                storageInventoryUI.SetActive(true);
                depositAllButton.SetActive(true);
                uiManager.RefreshInventoryUI("Storage");
                audioManager.PlaySFX(openSound);
            }
            else
            {
                storageInventoryUI.SetActive(false);
                depositAllButton.SetActive(false);
                HoverTipManager.OnMouseLoseFocus();
                audioManager.PlaySFX(closeSound);
            }
        }
        
    }
}
