using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalEntry : MonoBehaviour
{

    public ItemData mushData;
    public FoundMushroomTracker tracker;
    public GameObject journalPanelTab;

    public int entryItemNumber;
    public GameObject icon;
    public GameObject iconColor;
    public GameObject mushName;

    [field: SerializeField] 
    public List<GameObject> knownInfoFeatures { get; set; }

    [field: SerializeField] 
    public List<GameObject> missingInfoFeatures { get; set; }


    //if the mushroom is found, flip all info over to known correct visuals
    void RevealAll()
    {
        if (tracker.mushroomByItemNumber[entryItemNumber]) 
        {
            foreach (GameObject feature in missingInfoFeatures)
            {
                feature.SetActive(false);
            }

            foreach (GameObject feature in knownInfoFeatures)
            {
                feature.SetActive(true);
            }
        }
    }

    void RandomKnowledge()
    {
        //festures in the entry we want to potentially show, as ints
        List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        //Fisher-Yates shuffle that list
        for (int i = numbers.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }

        //reveal four details about the entry without having to discover them
        int q = 0;
        while (q < 4)
        {
            int z = numbers[q];
            knownInfoFeatures[z].SetActive(true);
            missingInfoFeatures[z].SetActive(false);
            q += 1;
        }

    }

    void Awake()
    {
        entryItemNumber = mushData.itemNumber;
        icon.GetComponent<Image>().sprite = mushData.icon;
        iconColor.GetComponent<Image>().color = mushData.iconColor;
        mushName.GetComponent<TMP_Text>().text = mushData.itemName;

        // make sure this is off in final
        //should only happen once at begining of playthrough for a new game
        RandomKnowledge();
    }


    void Start()
    {
        //RandomKnowledge();
    }

    void Update()
    {
        if (journalPanelTab.activeSelf)
        {
            RevealAll();
        }
    }
}
