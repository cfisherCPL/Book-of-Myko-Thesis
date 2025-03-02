using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using UnityEngine.UI;

public class LetterRequests : MonoBehaviour
{
    [SerializeField] public LetterRequestTracker reqTracker;
    [SerializeField] public GameObject popupFeature;
    [SerializeField] public GameObject backpackPanel;

    [SerializeField] public Inventory_UI backpackUI;
    [SerializeField] public Inventory_UI letterReqUI;
    [SerializeField] public Sprite sentImage;

    public string inventoryName;
    private Inventory inventoryToCheck;

    private bool inRange = false;

    [SerializeField] ItemData[] allMushies;

    public int[] reqItemNums = new int[3];


    [SerializeField] public Image item1Icon;
    [SerializeField] public TMP_Text item1Text;

    [SerializeField] public Image item2Icon;
    [SerializeField] public TMP_Text item2Text;

    [SerializeField] public Image item3Icon;
    [SerializeField] public TMP_Text item3Text;


    [SerializeField] public GameObject SubmitButton;
    [SerializeField] public TMP_Text RequestTextArea;


    public string[] RequestTexts = new string[15]
     {
        "I'd really like to chow down on these if you can find them.",
        "I'm making a tincture for a client and need these, please.",
        "Doing some special research and need a few things.",
        "Need a remedy for a sick family member, and only these will do.",
        "So much research, and ran out of samples. Do you have these?",
        "Grandma made a mean veggie pizza, but these would top it off!",
        "These would be so pretty in my bouquet.",
        "I need help with my Academy entrance journal. These are my last three.",
        "Maybe you can find these for the town apothecary?",
        "Long camping trip coming up. These would help see the stars.",
        "Can't seem to find these anymore. Maybe you can.",
        "It would mean the world if you could send these to us.",
        "Do these grow there? I'd be so happy if you could help.",
        "The Academy has an official special request for these today.",
        "My wife would like to use these for a new tincture.",
     };



    private void Awake()
    {
        popupFeature.SetActive(false);
        SubmitButton.SetActive(false);
    }


    void Start()
    {
        //
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
        if (popupFeature.activeSelf)
        {
            popupFeature.SetActive(false);
        }
        
        backpackPanel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (popupFeature.activeSelf)
        {
            
            int allItemCount = 0;
            for(int i = 0; i < inventoryToCheck.slots.Count; i++ )
            {
                if (inventoryToCheck.slots[i].itemNumber == reqItemNums[i])
                {
                    allItemCount++;
                } 
            }
            if (allItemCount == 3)
            {
                SubmitButton.SetActive(true);
            }
            else
            {
                SubmitButton.SetActive(false);
            }
        }


        if (inRange && Input.GetKeyDown("e"))
        {
            

            backpackUI.Refresh();

        }


    }

    public void GenerateNewRequest()
    {
        //festures in the entry we want to potentially show, as ints
        int[] numbers = new int[allMushies.Length];

        for (int i = 0; i < allMushies.Length; i++) 
        {
            numbers[i] = i;
        }

        //Fisher-Yates shuffle that list
        for (int i = numbers.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }

        //add three random items to the Request using the first three items of numbers
        
            
        item1Text.text = allMushies[numbers[0]].itemName;
        item1Icon.sprite = allMushies[numbers[0]].icon;
        item1Icon.color = allMushies[numbers[0]].iconColor;
        reqItemNums[0] = allMushies[numbers[0]].itemNumber;

        item2Text.text = allMushies[numbers[1]].itemName;
        item2Icon.sprite = allMushies[numbers[1]].icon;
        item2Icon.color = allMushies[numbers[1]].iconColor;
        reqItemNums[1] = allMushies[numbers[1]].itemNumber;


        item3Text.text = allMushies[numbers[2]].itemName;
        item3Icon.sprite = allMushies[numbers[2]].icon;
        item3Icon.color = allMushies[numbers[2]].iconColor;
        reqItemNums[2] = allMushies[numbers[2]].itemNumber;

        //add some flavor text!
        int k = UnityEngine.Random.Range(0, RequestTexts.Length);
        RequestTextArea.text = RequestTexts[k];

    }

    public void TestRequestDeposit()
    {
        item1Text.text = allMushies[0].itemName;
        item1Icon.sprite = allMushies[0].icon;
        item1Icon.color = allMushies[0].iconColor;
        reqItemNums[0] = allMushies[0].itemNumber;

        item2Text.text = allMushies[0].itemName;
        item2Icon.sprite = allMushies[0].icon;
        item2Icon.color = allMushies[0].iconColor;
        reqItemNums[1] = allMushies[0].itemNumber;


        item3Text.text = allMushies[0].itemName;
        item3Icon.sprite = allMushies[0].icon;
        item3Icon.color = allMushies[0].iconColor;
        reqItemNums[2] = allMushies[0].itemNumber;
    }


    public void SendItems()
    {
        foreach (Inventory.Slot slot in inventoryToCheck.slots)
        {
       
            slot.RemoveItem();
    
        }


        item1Text.text = "Sent!";
        item1Icon.sprite = sentImage;
        
        item2Text.text = "Sent!";
        item2Icon.sprite = sentImage;

        item3Text.text = "Sent!";
        item3Icon.sprite = sentImage;

        reqTracker.requestsCompleted++;

        RequestTextArea.text = "Thank you little mycologist!";

    }

}