using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;


    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
     public int ammoAmount;
    }

    public int GetAmmoCount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }


    public void ReduceAmmoAmount(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }


    public void IncreaseAmmoAmount(AmmoType ammoType,int Amount)
    {
        GetAmmoSlot(ammoType).ammoAmount += Amount ;
    }


    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }



}
