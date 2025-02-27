using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLoadProtection : MonoBehaviour
{
    public static InventoryLoadProtection instance { get; private set; }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

    }

}
