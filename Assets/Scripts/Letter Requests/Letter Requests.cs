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
    [SerializeField] public GameObject requestPanel;


    [SerializeField] public Inventory_UI backpackUI;
    [SerializeField] public Inventory_UI letterReqUI;
    [SerializeField] public Sprite sentImage;

    public string inventoryName;
    private Inventory inventoryToCheck;

    private bool inRange = false;

    [SerializeField] ItemData[] allMushies;
    [SerializeField] GameObject[] greenChecks;

    public int[] reqItemNums = new int[3];


    [SerializeField] public Image item1Icon;
    [SerializeField] public TMP_Text item1Text;

    [SerializeField] public Image item2Icon;
    [SerializeField] public TMP_Text item2Text;

    [SerializeField] public Image item3Icon;
    [SerializeField] public TMP_Text item3Text;


    [SerializeField] public GameObject SubmitButton;
    [SerializeField] public TMP_Text RequestTextArea;

    [SerializeField] public CurrentRequest currentRequest;

    public bool currentReqCompleted;

    [SerializeField] public GameObject specialMushroom;
    [SerializeField] public Transform mushSpawnLoc;



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
        requestPanel.SetActive(false);
    }


    void Start()
    {
        //
        inventoryToCheck = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Request Trigger");

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
        if (inRange && Input.GetKeyDown("e"))
        {
            if (!requestPanel.activeSelf)
            {
                requestPanel.SetActive(true);
            }
            else
            {
                requestPanel.SetActive(false);
                HoverTipManager.OnMouseLoseFocus();
            }
            
            
        }

        if (requestPanel.activeSelf)
        {
            if (!currentReqCompleted)
            {
                int allItemCount = 0;

                for (int i = 0; i < inventoryToCheck.slots.Count; i++)
                {
                    if (inventoryToCheck.slots[i].itemNumber == reqItemNums[i])
                    {
                        allItemCount++;
                        greenChecks[i].SetActive(true);
                    }
                    else
                    {
                        allItemCount--;
                        greenChecks[i].SetActive(false);
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

            backpackUI.Refresh();
        }

    }

    public void GenerateNewRequest()
    {
        if (currentReqCompleted == true)
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

            //save the current request information for saving
            currentRequest.mush1 = numbers[0];
            currentRequest.mush2 = numbers[1];
            currentRequest.mush3 = numbers[2];
            currentRequest.reqText = k;

            currentReqCompleted = false;
            
        }

    }

    public void LoadExistingRequest()
    {
        item1Text.text = allMushies[currentRequest.mush1].itemName;
        item1Icon.sprite = allMushies[currentRequest.mush1].icon;
        item1Icon.color = allMushies[currentRequest.mush1].iconColor;
        reqItemNums[0] = allMushies[currentRequest.mush1].itemNumber;

        item2Text.text = allMushies[currentRequest.mush2].itemName;
        item2Icon.sprite = allMushies[currentRequest.mush2].icon;
        item2Icon.color = allMushies[currentRequest.mush2].iconColor;
        reqItemNums[1] = allMushies[currentRequest.mush2].itemNumber;


        item3Text.text = allMushies[currentRequest.mush3].itemName;
        item3Icon.sprite = allMushies[currentRequest.mush3].icon;
        item3Icon.color = allMushies[currentRequest.mush3].iconColor;
        reqItemNums[2] = allMushies[currentRequest.mush3].itemNumber;

        RequestTextArea.text = RequestTexts[currentRequest.reqText];
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

        foreach (GameObject mark in greenChecks)
        { mark.SetActive(false); }


        item1Text.text = "Sent!";
        item1Icon.sprite = sentImage;
        reqItemNums[0] = 666;
        
        item2Text.text = "Sent!";
        item2Icon.sprite = sentImage;
        reqItemNums[1] = 666;

        item3Text.text = "Sent!";
        item3Icon.sprite = sentImage;
        reqItemNums[2] = 666;

        reqTracker.requestsCompleted++;

        RequestTextArea.text = "Thank you little mycologist!";

        currentReqCompleted = true;

        SubmitButton.SetActive(false);

        if (reqTracker.requestsCompleted % 5 == 0)
        {
            GameObject giftMush = Instantiate(specialMushroom, mushSpawnLoc.position, mushSpawnLoc.rotation, this.transform);
        }

    }


    public void NewGameRequestSetup()
    {
        currentReqCompleted = true;
        GenerateNewRequest();
    }
}