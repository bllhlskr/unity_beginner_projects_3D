using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleWeapons : MonoBehaviour
{
    public bool Flag = true;
    int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

   



    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
        
             
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag)
        {
            int previosuWeapon = currentWeapon;
            ProcessKeyInput();
            ProcessScrollWheel();
            if (previosuWeapon != currentWeapon)
            {
                SetWeaponActive();
            }
        }
      
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon < 0 )
            {
                currentWeapon = 3;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
        }
    }
}


