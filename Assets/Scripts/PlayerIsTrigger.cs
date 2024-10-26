using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsTrigger : MonoBehaviour
{

    public InventoryTest inventory;

    private void Awake()
    {
        inventory = new InventoryTest(21);
    }

    
}
