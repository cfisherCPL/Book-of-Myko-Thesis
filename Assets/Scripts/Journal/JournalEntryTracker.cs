using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntryTracker : MonoBehaviour
{
    [field: SerializeField]
    public List<GameObject> panelEntries { get; set; }
}
