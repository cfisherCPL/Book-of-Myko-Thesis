using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositButtonManager : MonoBehaviour
{
    public GameObject storagePanel;
    public GameObject depositButton;
    
    
    void Awake()
    {
        depositButton = this.gameObject;
    }
    void Start()
    {
        //depositButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!storagePanel.activeSelf) 
        {
            depositButton.SetActive(false);

        }
    }
}
