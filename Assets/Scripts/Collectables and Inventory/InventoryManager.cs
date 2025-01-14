using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance {  get; private set; }

    public Inventory inventory;

    private void Awake()
    {
        //singleton pattern to persist across scenes
      
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
      
        inventory = new Inventory(8);
    }

    /* 1-14-25 Not sure this manager is ever used?
     * not referenced by anything, and the PlayerIsTrigger manages 
     * its own inventory 
     * 
     * */
}
