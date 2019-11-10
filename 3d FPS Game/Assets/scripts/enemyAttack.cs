using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float damage = 20f;

    // Start is called before the first frame update
    void Start()
    {

        
    }
    public void OnDamageTaken()
    {
        Debug.Log(name + "fuck you mother fucker");
    }
        
    public void AttackHitEvent()
    {
        if (target == null) return;
        Debug.Log("bang bang");
        FindObjectOfType<playerHealth>().GetDamage(damage);
        

    }


    
}
