using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenTruffleGenerator : MonoBehaviour
{
    [SerializeField] public Transform mushSpawnLocation;
    [SerializeField] public GameObject mushPreFab;

    [SerializeField] public Truffle_Pets petsTracker;


    public void CheckForPets()
    {
        if (petsTracker.timesPet > 0)
        {
            if (petsTracker.timesPet % 10 == 0)
            {
                GameObject giftMush = Instantiate(mushPreFab, mushSpawnLocation.position, mushSpawnLocation.rotation, this.transform);
            }
        }
    }


}
