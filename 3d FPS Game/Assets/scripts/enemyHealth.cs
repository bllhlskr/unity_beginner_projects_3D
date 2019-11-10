using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    // create public method whic reduces hitpoints by amount of damage

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        GetComponent<enemyAI>().OnDamageTaken();
        hitPoints -= damage;

            if(hitPoints<= 0)
        {
            Die();
            Destroy(gameObject);
        }
    }
    private void Die()
    {
        GetComponent<Animator>().SetTrigger("die");
    }










}
