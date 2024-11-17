using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsTrigger : MonoBehaviour
{

    public InventoryTest inventory;
    public static PlayerIsTrigger Instance { get; private set; }

    private void Awake()
    {

        inventory = new InventoryTest(21);

    }

    
}
