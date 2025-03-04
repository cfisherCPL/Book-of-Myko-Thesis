using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject journal;
    [SerializeField] public TimeOfDay currentTime;
    [SerializeField] public DayOfWeek currentDay;
    [SerializeField] public AlreadySpawned spawnTracker;
    [SerializeField] public FoundMushroomTracker foundTracker;

    
    [SerializeField] public NewGameTracker newGameTracker;
    [SerializeField] public GameObject gameManager;

    public GameObject[] menuPanels;

    //all the different mushroom info pages in the journal that need save states

    [SerializeField] public GameObject commonJournalPanel;
    [SerializeField] public GameObject forestJournalPanel;
    [SerializeField] public GameObject grasslandsJournalPanel;
    [SerializeField] public GameObject mountainJournalPanel;
    [SerializeField] public GameObject specialJournalPanel;

    [SerializeField] public GameObject[] journalTrackers;

    [SerializeField] public SaveExistsTracker saveFileExists;
    [SerializeField] public CurrentRequest currentRequest;

    private string saveLocation;
   
    void Awake()
    {
     
    }
    
    void Start()
    {
        //define the save location
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");

        if (File.Exists(saveLocation))
        {
            saveFileExists.saveFileExists = true;
        }
        else
        {
            saveFileExists.saveFileExists = false;
        }

    }


    public void SaveGame()
    {
        int playerBackpack = player.GetComponent<InventoryManager>().backpackSlotsCount;       
        int playerStorage = player.GetComponent<InventoryManager>().storageSlotsCount;
        int playerLetterBox = player.GetComponent<InventoryManager>().giftsSlotsCount;
        int foundListNum = foundTracker.mushroomByItemNumber.Count;
        UnityEngine.Debug.Log("ListNum was " + foundListNum);


        SaveData saveData = new SaveData
        {
            playerPosition = player.transform.position,
            dayOfWeek = currentDay.currentDay,
            timeOfDay = currentTime.currentTimeOfDay,
            alreadySpawned = spawnTracker.alreadySpawned,
            foundMushList = new List<bool>(foundListNum),
            //journalPanel_common = new JournalPanelSaveData(journalTrackers[0].GetComponent<JournalEntryTracker>().panelEntries.Count),
            //journalPanel_forest = new JournalPanelSaveData(journalTrackers[1].GetComponent<JournalEntryTracker>().panelEntries.Count),
            //journalPanel_grasslands = new JournalPanelSaveData(journalTrackers[2].GetComponent<JournalEntryTracker>().panelEntries.Count),
            //journalPanel_mountain = new JournalPanelSaveData(journalTrackers[3].GetComponent<JournalEntryTracker>().panelEntries.Count),
            //journalPanel_special = new JournalPanelSaveData(journalTrackers[4].GetComponent<JournalEntryTracker>().panelEntries.Count),
            saveBackpack = new Inventory(playerBackpack),
            saveStorage = new Inventory(playerStorage),
            saveLetterBox = new Inventory(playerLetterBox),
            requestSaveData = new RequestSaveData()
        };

        
        saveData.requestSaveData.mush1 = currentRequest.mush1;
        saveData.requestSaveData.mush2 = currentRequest.mush2;
        saveData.requestSaveData.mush3 = currentRequest.mush3;
        saveData.requestSaveData.reqText = currentRequest.reqText;
        


        //make new JPSD in the SaveData array for them using the number of entries per panel tracker
        for (int i=0; i<saveData.allPanels.Length; i++)
        {
            saveData.allPanels[i] = new JournalPanelSaveData(journalTrackers[i].GetComponent<JournalEntryTracker>().panelEntries.Count);
        }

        //read playerbackpack into saveData
        for (int i = 0; i < saveData.saveBackpack.slots.Count; i++)
        {
            saveData.saveBackpack.slots[i].itemName = player.GetComponent<InventoryManager>().backpack.slots[i].itemName;
            saveData.saveBackpack.slots[i].itemNumber = player.GetComponent<InventoryManager>().backpack.slots[i].itemNumber;
            saveData.saveBackpack.slots[i].count = player.GetComponent<InventoryManager>().backpack.slots[i].count;
            saveData.saveBackpack.slots[i].maxAllowed = player.GetComponent<InventoryManager>().backpack.slots[i].maxAllowed;
            saveData.saveBackpack.slots[i].icon = player.GetComponent<InventoryManager>().backpack.slots[i].icon;
            saveData.saveBackpack.slots[i].iconColor = player.GetComponent<InventoryManager>().backpack.slots[i].iconColor;
        }

        //read player storage into saveData
        for (int i = 0; i < saveData.saveStorage.slots.Count; i++)
        {
            saveData.saveStorage.slots[i].itemName = player.GetComponent<InventoryManager>().storage.slots[i].itemName;
            saveData.saveStorage.slots[i].itemNumber = player.GetComponent<InventoryManager>().storage.slots[i].itemNumber;
            saveData.saveStorage.slots[i].count = player.GetComponent<InventoryManager>().storage.slots[i].count;
            saveData.saveStorage.slots[i].maxAllowed = player.GetComponent<InventoryManager>().storage.slots[i].maxAllowed;
            saveData.saveStorage.slots[i].icon = player.GetComponent<InventoryManager>().storage.slots[i].icon;
            saveData.saveStorage.slots[i].iconColor = player.GetComponent<InventoryManager>().storage.slots[i].iconColor;
        }

        //read player items left in the letter box areas into saveData
        for (int i = 0; i < saveData.saveLetterBox.slots.Count; i++)
        {
            saveData.saveLetterBox.slots[i].itemName = player.GetComponent<InventoryManager>().letterGifts.slots[i].itemName;
            saveData.saveLetterBox.slots[i].itemNumber = player.GetComponent<InventoryManager>().letterGifts.slots[i].itemNumber;
            saveData.saveLetterBox.slots[i].count = player.GetComponent<InventoryManager>().letterGifts.slots[i].count;
            saveData.saveLetterBox.slots[i].maxAllowed = player.GetComponent<InventoryManager>().letterGifts.slots[i].maxAllowed;
            saveData.saveLetterBox.slots[i].icon = player.GetComponent<InventoryManager>().letterGifts.slots[i].icon;
            saveData.saveLetterBox.slots[i].iconColor = player.GetComponent<InventoryManager>().letterGifts.slots[i].iconColor;
        }

        //read scriptable obj for found mushrooms into saveData
        for (int i = 0; i < foundTracker.mushroomByItemNumber.Count; i++) 
        {
            saveData.foundMushList.Add(foundTracker.mushroomByItemNumber[i]);
        }
        //UnityEngine.Debug.Log("Count of SO Tracker is: " + foundTracker.mushroomByItemNumber.Count);
        //UnityEngine.Debug.Log("Count of Saved Tracker List is: " + saveData.foundMushList.Count);
        //UnityEngine.Debug.Log("Capacity of Saved Tracker List is: " + saveData.foundMushList.Capacity);

        UnityEngine.Debug.Log("saveData.allPanels.Lenght is: " + saveData.allPanels.Length);

        //copy the state data of each element in the each journal panel
        for (int q = 0; q < saveData.allPanels.Length; q++)
        {
            int entryCount = journalTrackers[q].GetComponent<JournalEntryTracker>().panelEntries.Count;
            for (int i = 0; i < entryCount; i++)
            {
                int knownInfo = 12;
                for (int j = 0; j < knownInfo; j++)
                {
                    bool temp = false;
                    temp = journalTrackers[q].GetComponent<JournalEntryTracker>().panelEntries[i].GetComponent<JournalEntry>().knownTracker[j];
                    saveData.allPanels[q].entryTracker[i].knownTracker[j] = temp;
                }

                int missingInfo = 12;
                for (int j = 0; j < missingInfo; j++)
                {
                    bool temp = false;
                    temp = journalTrackers[q].GetComponent<JournalEntryTracker>().panelEntries[i].GetComponent<JournalEntry>().missingTracker[j];
                    saveData.allPanels[q].entryTracker[i].missingTracker[j] = temp;
                }
            }
        }



        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));

        UnityEngine.Debug.Log("Data was Saved!");
        //UnityEngine.Debug.Log("The first bool in saveList is: " + saveData.foundMushList[0]);

        saveFileExists.saveFileExists = true;
    }



    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            menuPanels = GameObject.FindGameObjectsWithTag("MenuPanel");

            foreach (GameObject panel in menuPanels)
            {
                panel.SetActive(false);
            }

            
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            player.transform.position = saveData.playerPosition;
            currentDay.currentDay = saveData.dayOfWeek;
            currentTime.currentTimeOfDay = saveData.timeOfDay;
            spawnTracker.alreadySpawned = saveData.alreadySpawned;

            

            for (int i = 0; i < saveData.saveStorage.slots.Count; i++)
            {
                player.GetComponent<InventoryManager>().storage.slots[i].itemName = saveData.saveStorage.slots[i].itemName ;
                player.GetComponent<InventoryManager>().storage.slots[i].itemNumber = saveData.saveStorage.slots[i].itemNumber;
                player.GetComponent<InventoryManager>().storage.slots[i].count = saveData.saveStorage.slots[i].count;
                player.GetComponent<InventoryManager>().storage.slots[i].maxAllowed = saveData.saveStorage.slots[i].maxAllowed;
                player.GetComponent<InventoryManager>().storage.slots[i].icon = saveData.saveStorage.slots[i].icon;
                player.GetComponent<InventoryManager>().storage.slots[i].iconColor = saveData.saveStorage.slots[i].iconColor;
            }

            for (int i = 0; i < saveData.saveBackpack.slots.Count; i++)
            {
                player.GetComponent<InventoryManager>().backpack.slots[i].itemName = saveData.saveBackpack.slots[i].itemName;
                player.GetComponent<InventoryManager>().backpack.slots[i].itemNumber = saveData.saveBackpack.slots[i].itemNumber;
                player.GetComponent<InventoryManager>().backpack.slots[i].count = saveData.saveBackpack.slots[i].count;
                player.GetComponent<InventoryManager>().backpack.slots[i].maxAllowed = saveData.saveBackpack.slots[i].maxAllowed;
                player.GetComponent<InventoryManager>().backpack.slots[i].icon = saveData.saveBackpack.slots[i].icon;
                player.GetComponent<InventoryManager>().backpack.slots[i].iconColor = saveData.saveBackpack.slots[i].iconColor;
            }

            for (int i = 0; i < saveData.saveLetterBox.slots.Count; i++)
            {
                player.GetComponent<InventoryManager>().letterGifts.slots[i].itemName = saveData.saveLetterBox.slots[i].itemName;
                player.GetComponent<InventoryManager>().letterGifts.slots[i].itemNumber = saveData.saveLetterBox.slots[i].itemNumber;
                player.GetComponent<InventoryManager>().letterGifts.slots[i].count = saveData.saveLetterBox.slots[i].count;
                player.GetComponent<InventoryManager>().letterGifts.slots[i].maxAllowed = saveData.saveLetterBox.slots[i].maxAllowed;
                player.GetComponent<InventoryManager>().letterGifts.slots[i].icon = saveData.saveLetterBox.slots[i].icon;
                player.GetComponent<InventoryManager>().letterGifts.slots[i].iconColor = saveData.saveLetterBox.slots[i].iconColor;
            }


            for (int i = 0; i < foundTracker.mushroomByItemNumber.Count; i++)
            {
                bool temp = false;
                temp = saveData.foundMushList[i];
                foundTracker.mushroomByItemNumber[i] = temp;
                    
            }


            currentRequest.mush1 = saveData.requestSaveData.mush1;
            currentRequest.mush2 = saveData.requestSaveData.mush2;
            currentRequest.mush3 = saveData.requestSaveData.mush3;
            currentRequest.reqText = saveData.requestSaveData.reqText;

            /*
            //copy the state data of each element in the journal panel for common mushrooms
            int entryCount = commonJournalPanel.GetComponent<JournalEntryTracker>().panelEntries.Count;
            for (int i = 0; i < entryCount; i++)
            {
                int knownInfo = 12;
                for (int j = 0; j < knownInfo; j++)
                {
                    bool temp = false;
                    temp = saveData.journalPanel_common.entryTracker[i].knownTracker[j];
                    commonJournalPanel.GetComponent<JournalEntryTracker>().panelEntries[i].GetComponent<JournalEntry>().knownTracker[j] = temp;
                    
                }

                int missingInfo = 12;
                for (int j = 0; j < missingInfo; j++)
                {
                    bool temp = false;
                    temp = saveData.journalPanel_common.entryTracker[i].missingTracker[j];
                    commonJournalPanel.GetComponent<JournalEntryTracker>().panelEntries[i].GetComponent<JournalEntry>().missingTracker[j] = temp;
                    
                }

            }
            */

            for (int q = 0; q < saveData.allPanels.Length; q++)
            {
                int entryCount = journalTrackers[q].GetComponent<JournalEntryTracker>().panelEntries.Count;
                for (int i = 0; i < entryCount; i++)
                {
                    int knownInfo = 12;
                    for (int j = 0; j < knownInfo; j++)
                    {
                        bool temp = false;
                        temp = saveData.allPanels[q].entryTracker[i].knownTracker[j];
                        journalTrackers[q].GetComponent<JournalEntryTracker>().panelEntries[i].GetComponent<JournalEntry>().knownTracker[j] = temp;
                        
                    }

                    int missingInfo = 12;
                    for (int j = 0; j < missingInfo; j++)
                    {
                        bool temp = false;
                        temp = saveData.allPanels[q].entryTracker[i].missingTracker[j];
                        journalTrackers[q].GetComponent<JournalEntryTracker>().panelEntries[i].GetComponent<JournalEntry>().missingTracker[j] = temp;
                        
                    }
                }
            }

            UnityEngine.Debug.Log("Data was Loaded!");
        }
        else
        {
            SaveGame();
        }

    }

    public void NewGameClean()
    {
        foreach (GameObject journalTracker in journalTrackers)
        {
            for (int i = 0; i < journalTracker.GetComponent<JournalEntryTracker>().panelEntries.Count; i++)
            {
                JournalEntry entry = journalTracker.GetComponent<JournalEntryTracker>().panelEntries[i].GetComponent<JournalEntry>();
                entry.ResetAll();
                entry.RandomKnowledge();
            }

        }
    }

}
