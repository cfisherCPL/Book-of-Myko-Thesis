using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsTrigger : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private int inventorySlots;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }
        
    //public Inventory inventory;
    public bool inventoryFull = false;
    //public Inventory toolbar;
    public InventoryManager inventory;

   

    //singleton pattern disabled 11-19-24
    //public static PlayerIsTrigger Instance { get; private set; }

    private void Awake()
    {

        inventory = GetComponent<InventoryManager>();

 
    }

    public void DropItem (Item item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        droppedItem.tag = "DroppedMushroom";

        droppedItem.rb2D.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    }

    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++) 
        {
            DropItem(item);
        }
    }

    private void Update()
    {
        //if (dialogueUI.IsOpen) return;

        if (Input.GetKeyDown("e") && !dialogueUI.IsOpen)
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

      
    }

    
}
