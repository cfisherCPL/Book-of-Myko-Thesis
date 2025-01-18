using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    /* refactoring items to use Scriptable Objects 1-14-25
     * many features of this were split between Item and ItemData
     * Keeping some features based on custom use in how
     * Inventory handles moving items to a Slot prefab
     * 
     * Part of this refactor means PickupItem is 
     * only responsible for collision and sending out
     * an Add/Destory command for the prefab in the scene
     * and turning it into a thing in Inventory
     */
    public Sprite icon;
    public Color iconColor;
    
    public UnityEvent itemWasTouched;
    AudioSource soundEffect;
    Collider2D trigger;
    [SerializeField] private TMP_Text popupText;

    /*We're done using points and Stamina 1-14-25
    [SerializeField] private int pointsPerCollect;
    [SerializeField] private int staminaCost;
    private ScoreManager _scoreController;
    private StaminaManager _staminaController;
    */

    private bool canPickUp;

    // THIS is where InventoryManager is made...but never used?
    InventoryManager inventoryTarget;

    PlayerIsTrigger playerTarget;

    public UnityEvent itemPickedUp;

    public Item item;
    public Mushroom mushroom;


    PlayerIsTrigger playerTemp;

   private void Awake()
   {
        //_scoreController = FindObjectOfType<ScoreManager>();
        //_staminaController = FindObjectOfType<StaminaManager>();
        //icon = GetComponent<Sprite>();
        //iconColor = GetComponent<Color>();
        
        soundEffect = GetComponent<AudioSource>();
        trigger = GetComponent<Collider2D>();
        item = GetComponent<Item>();
        mushroom = GetComponent<Mushroom>();
        canPickUp = false;

        //find the inventory manager in the scene to make it the target to place items
        inventoryTarget = FindObjectOfType<InventoryManager>();

        //this is where we share components with Slot
        //to make the inventory item look like the actual pickupItem
        SpriteRenderer thisSprite = GetComponent<SpriteRenderer>();
        icon = thisSprite.sprite;
        iconColor = thisSprite.color;

        //update the scriptable objects using existing data
        //test: it doesnt work 1-14-25
        item.data.iconColor = iconColor;
        item.data.icon = icon;
        item.data.itemName = mushroom.mushName;

        popupText.gameObject.SetActive(false);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerIsTrigger player = collision.GetComponent<PlayerIsTrigger>();
        playerTarget = player;
        playerTemp = player;
        Item item = this.item;


        if (player && playerTarget.inventory.backpack.ItemCanBeSlotted(item))
        {
            popupText.SetText("Press F to Pickup");
            popupText.gameObject.SetActive(true);
            canPickUp = true;

        }
        else if (player && !playerTarget.inventory.backpack.ItemCanBeSlotted(item))
        {
            popupText.SetText("Backpack is Full");
            popupText.gameObject.SetActive(true);
            canPickUp = false;
        }

    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        popupText.SetText("");
        popupText.gameObject.SetActive(false);
        canPickUp = false;
        playerTemp = null;
    }

    public void Update()
    {
        
        if (canPickUp && Input.GetKeyDown("f"))
        {
            Item item = GetComponent<Item>();

            if (playerTarget.inventory.backpack.ItemCanBeSlotted(item)) 
            { 
                if (item != null)
                {
                    playerTarget.inventory.Add("Backpack", item);
                    itemPickedUp.Invoke();
                    soundEffect.Play();
                    Destroy(this.gameObject, 0.1f);
                }
            }
            else
            {
                popupText.SetText("Backpack is Full");
                popupText.gameObject.SetActive(true);
                canPickUp = false;
            }
            
        }
    }



}
/* CollectableType will be deprecated with Item refactoring 1-14-25
 * it may still be useable, and full delete will require fixing LOTS
 * hold and comment out for now until refactor and rebuild of items is complete
 * */

/*
public enum CollectableType
{
    NONE, INDIGO_MUSH1,
    BASIC_BTN,SUNNY_BTN,MOONLIT_BTN,WORKER_BTN,DAYSHIFT_BTN,NIGHTSHIFT_BTN,PARTY_BTN,BRUNCH_BTN,NIGHTCAP_BTN,
    LUNA,MARS,MERCURY,JUPITER,VENUS,SATURN,SOL,
    THICKET_TRUMPET,TIMBER_CAP,WOODLAND_COMB, THICKET_OYSTER, TIMBER_TOADSTOOL, WOODLAND_MANE, THICKET_PILLOW, TIMBER_SUNBURST, WOODLAND_MOONLUMP,
    PASTURE_TRUMPET, PRAIRIE_CAP, PLAINS_COMB, PASTURE_OYSTER, PRAIRIE_TOADSTOOL, PLAINS_MANE, PASTURE_PILLOW, PRAIRIE_SUNBURST, PLAINS_MOONLUMP,
    ALPINE_TRUMPET, HIGHLANDS_CAP, STONY_COMB, ALPINES_OYSTER, HIGHLAND_TOADSTOOL, STONY_MANE, ALPINE_PILLOW, HIGHLANDS_SUNBURST, STONY_MOONLUMP,
    SYL_CRWN,SYL_PARA,SYL_FNNL,SYL_PUFF,SYL_FNGS,SYL_SHLD,SYL_TRUF,
    TAL_CRWN,TAL_PARA,TAL_FNNL,TAL_PUFF,TAL_FNGS,TAL_SHLD,TAL_TRUF,
    ROC_CRWN, ROC_PARA, ROC_FNNL, ROC_PUFF, ROC_FNGS, ROC_SHLD, ROC_TRUF,
}
*/