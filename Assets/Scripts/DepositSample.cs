using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class DepositSample : MonoBehaviour
{
    [SerializeField] public GameObject popupFeature;
    [SerializeField] public FoundMushroomTracker mushroomTracker;
    [SerializeField] public Inventory_UI backpackUI;
    [SerializeField] public GameObject backpackPanel;
    
    public string inventoryName;
    private Inventory inventoryToCheck;

    private bool inRange = false;

    AudioManager audioManager;
    [SerializeField] AudioClip depositSound;

    private bool itemsDeposited;

    private void Awake()
    {
        popupFeature.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }


    void Start()
    {
        inventoryToCheck = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Deposit Trigger");

        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerIsTrigger player))
        {
            popupFeature.SetActive(true);
            backpackPanel.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
        Debug.Log("Exited Deposit Trigger");
        popupFeature.SetActive(false);
        backpackPanel.SetActive(false);
      

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown("e"))
        {
            itemsDeposited = false;
            
            foreach (Inventory.Slot slot in inventoryToCheck.slots) 
            {
                
                if (slot.itemNumber < mushroomTracker.mushroomByItemNumber.Count)
                {
                    if (!mushroomTracker.mushroomByItemNumber[slot.itemNumber])
                    {
                        mushroomTracker.mushroomByItemNumber[slot.itemNumber] = true;
                        slot.RemoveItem();
                        itemsDeposited = true;
                    }
                }
            }
            
            backpackUI.Refresh();

            if (itemsDeposited)
            {
                audioManager.PlaySFX(depositSound);
            }
            
            itemsDeposited = false;
        }
    }
}
