using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoundMushroomTracker : ScriptableObject
{
    [field: SerializeField]
    public List<bool> mushroomByItemNumber { get; set; }

    public int totalFound;
    


}
