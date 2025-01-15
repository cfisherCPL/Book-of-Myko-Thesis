using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsTrigger : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private int inventorySlots;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    public Inventory inventory;
    public bool inventoryFull = false;

    //singleton pattern disables 11-19-24
    //public static PlayerIsTrigger Instance { get; private set; }

    private void Awake()
    {

        inventory = new Inventory(inventorySlots);

        inventory.inventory_UI = FindObjectOfType<Inventory_UI>();  
        //disable singleton pattern for new single scene verrsion
        /*
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        */
    }

    public void DropItem (Item item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        droppedItem.tag = "DroppedMushroom";

        droppedItem.rb2D.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    }

    private void Update()
    {
        //if (dialogueUI.IsOpen) return;

        if (Input.GetKeyDown("e") && dialogueUI.IsOpen != true)
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

      
    }

    
}
