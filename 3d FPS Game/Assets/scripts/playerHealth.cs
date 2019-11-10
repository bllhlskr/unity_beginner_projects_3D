using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void GetDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
           // Destroy(gameObject);
        }
        
    }
   
}
