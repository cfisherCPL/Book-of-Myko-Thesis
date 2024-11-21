using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsTrigger : MonoBehaviour
{

    public InventoryTest inventory;

    //singleton pattern disables 11-19-24
    //public static PlayerIsTrigger Instance { get; private set; }

    private void Awake()
    {

        inventory = new InventoryTest(14);

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

    
}
