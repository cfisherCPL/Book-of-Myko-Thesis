using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Truffle_Pets : ScriptableObject
{
    public int timesPet;


    public void PetOnce()
    {
        timesPet = timesPet + 1 ;
    }

    public void ResetPets()
    {
        timesPet = 0;
    }
}
