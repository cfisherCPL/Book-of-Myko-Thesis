using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item Data", order = 50)]
public class ItemData : ScriptableObject
{
    public int itemNumber = 0;
    public string itemName = "Item Name";
    public Sprite icon;
    public Color iconColor;

    

}
