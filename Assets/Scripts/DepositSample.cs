using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class DepositSample : MonoBehaviour
{
    [SerializeField] private TMP_Text popupText;
    [SerializeField] public FoundMushroomTracker mushroomTracker;
    [SerializeField] public Inventory_UI backpackUI;
    
    public string inventoryName;
    private Inventory inventoryToCheck;

    private bool inRange = false;


    private void Awake()
    {
        popupText.gameObject.SetActive(false);
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
            popupText.gameObject.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
        Debug.Log("Exited Deposit Trigger");
        popupText.gameObject.SetActive(false);
      

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown("e"))
        {
            foreach (Inventory.Slot slot in inventoryToCheck.slots) 
            {
                if (slot.itemNumber < mushroomTracker.mushroomByItemNumber.Count)
                {
                    if (!mushroomTracker.mushroomByItemNumber[slot.itemNumber])
                    {
                        mushroomTracker.mushroomByItemNumber[slot.itemNumber] = true;
                        slot.RemoveItem();
                    }
                }
            }
            
            backpackUI.Refresh();

        }
    }
}
