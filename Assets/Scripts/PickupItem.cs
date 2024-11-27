using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class PickupItem : MonoBehaviour
{
    //player enters trigger area of item
    //player pressed "pickup" button
    //item is added to player inventory
    //item is deleted from the scene

    public CollectableType itemType;
    public Sprite icon;

    public UnityEvent itemWasTouched;
    AudioSource soundEffect;
    Collider2D trigger;

    [SerializeField] private TMP_Text popupText;
    [SerializeField] private int pointsPerCollect;
    [SerializeField] private int staminaCost;

    private ScoreManager _scoreController;
    private StaminaManager _staminaController;
    private bool canPickUp;

    InventoryManager inventoryTarget;

    PlayerIsTrigger playerTarget;

   private void Awake()
   {
        _scoreController = FindObjectOfType<ScoreManager>();
        _staminaController = FindObjectOfType<StaminaManager>();
        soundEffect = GetComponent<AudioSource>();
        trigger = GetComponent<Collider2D>();
        popupText.gameObject.SetActive(false);
        canPickUp = false;

        //find the inventory manager in the scene to make it the target to place items
        inventoryTarget = FindObjectOfType<InventoryManager>();
        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerIsTrigger player = collision.GetComponent<PlayerIsTrigger>();
        playerTarget = player;

        if (player)
        {
            popupText.gameObject.SetActive(true);
            canPickUp = true;
            
            //manager features and old stamina system are for testing only
            //ScoreManager.Instance.IncreaseScore(pointsPerCollect);
            //StaminaManager.Instance.DecreaseStamina(staminaCost);
            //itemWasTouched.Invoke();
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(false);
        canPickUp = false;
    }

    public void Update()
    {
        if (canPickUp && Input.GetKeyDown("f"))
        {
            playerTarget.inventory.Add(this);
            soundEffect.Play();
            //inventoryTarget.inventory.Add(itemType);
            //not adding item to inventory bc cant find inventoryTarget
            Destroy(this.gameObject, 0.1f);
        }
    }



}

public enum CollectableType
{
    NONE, INDIGO_MUSH1,
    BASIC_BTN,SUNNY_BTN,MOONLIT_BTN,WORKER_BTN,DAYSHIFT_BTN,NIGHTSHIFT_BTN,PARTY_BTN,BRUNCH_BTN,NIGHTCAP_BTN,LUNA,MARS,MERCURY,JUPITER,VENUS,SATURN,SOL,
    THICKET_TRUMPET,TIMBER_CAP,WOODLAND_COMB, THICKET_OYSTER, TIMBER_TOADSTOOL, WOODLAND_MANE, THICKET_PILLOW, TIMBER_SUNBURST, WOODLAND_MOONLUMP,
    PASTURE_TRUMPET, PRAIRIE_CAP, PLAINS_COMB, PASTURE_OYSTER, PRAIRIE_TOADSTOOL, PLAINS_MANE, PASTURE_PILLOW, PRAIRIE_SUNBURST, PLAINS_MOONLUMP,
    ALPINE_TRUMPET, HIGHLANDS_CAP, STONY_COMB, ALPINES_OYSTER, HIGHLAND_TOADSTOOL, STONY_MANE, ALPINE_PILLOW, HIGHLANDS_SUNBURST, STONY_MOONLUMP,
    SYL_CRWN,SYL_PARA,SYL_FNNL,SYL_PUFF,SYL_FNGS,SYL_SHLD,SYL_TRUF,
    TAL_CRWN,TAL_PARA,TAL_FNNL,TAL_PUFF,TAL_FNGS,TAL_SHLD,TAL_TRUF,
    ROC_CRWN, ROC_PARA, ROC_FNNL, ROC_PUFF, ROC_FNGS, ROC_SHLD, ROC_TRUF,
}
