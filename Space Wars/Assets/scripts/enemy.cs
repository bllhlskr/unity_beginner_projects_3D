using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 0 ;
    [SerializeField] int scorePerHit = 12;
    
    ScoreBoard scoreboard;

   
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<ScoreBoard>();

    
   
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();

        boxCollider.isTrigger = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        scoreboard.ScoreHit(scorePerHit);
        hits++;
        if (hits >= 10)
        {
            KillEnemy();
        }
       
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        Destroy(gameObject);
    }
}
