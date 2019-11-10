using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem gunExplosion;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoSlot.GetAmmoCount(ammoType) > 0)
        {
            Shoot();
        }   
    }
    private void Shoot()
    {
        PlayGunExplosion();
        ProcessRaycast();
        ammoSlot.ReduceAmmoAmount(ammoType);
        
       
        
    }
    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            Debug.Log(" hit this thing" + hit.transform.name);
            enemyHealth target = hit.transform.GetComponent<enemyHealth>();
            if(target == null) return;

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject HitEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
        Destroy(HitEffect);


    }

    private void PlayGunExplosion()
    {

        gunExplosion.Play();
    }
    
}

