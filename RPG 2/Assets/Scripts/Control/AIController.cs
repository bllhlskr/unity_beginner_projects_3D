using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;

namespace RPG.Control{
    public class AIController : MonoBehaviour
{
   
    [SerializeField] float chaseDistance = 5f;
    Fighter fighter;
    GameObject player;
     void Start() {
        fighter = GetComponent<Fighter>(); 
        player= GameObject.FindWithTag("Player");
    }
     void Update()
        {
            
            if(InAttackRangeOfPlayer() ) {    //&& !fighter.CanAttack(player
                fighter.Attack(player);
            }
           else{
               fighter.Cancel();
            }
           // print(!fighter.CanAttack(player));
        }

        private bool  InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance ;
        }
    }

}