using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
    
    void Start()
    {
        ActivateTab(0);
    }

    public void ActivateTab(int tabNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }

        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;

    }



    //https://www.youtube.com/watch?v=liba3xGI4gM&list=PLaaFfzxy_80HtVvBnpK_IjSC8_Y9AOhuP&index=7
}
