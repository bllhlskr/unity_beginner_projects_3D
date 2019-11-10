using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {
        Health target;
        [SerializeField] float weaponRange= 2f;
        [SerializeField] float timeBetweenAttacks = 5f;
        [SerializeField] float weaponDamage = 5;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
             bool isInRange = GetIsInRange();
          

            if (target == null) return;
            if(target.ISDead())return;

            if (target != null && !isInRange )
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
                }
          }
        private void AttackBehavior()
        {
            transform.LookAt(target.transform);
         if (timeSinceLastAttack >= timeBetweenAttacks)
            {
                Hit();
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        private bool GetIsInRange()
        { if(target == null) return false;
            float Distance = Vector3.Distance(target.transform.position, transform.position);
            return   Distance < weaponRange ;
        }

        // public bool CanAttack(GameObject combattarget)
        //     {
        //         if(combattarget == null) return false;
        //        Health targetToTest = combattarget.GetComponent<Health>();
        //        return targetToTest != null && !targetToTest.ISDead();

        //     }
       
        public void Attack(GameObject combattarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);

            target = combattarget.GetComponent<Health>();
        } 
        public void Cancel()
        {
           StopAttack();
            target = null;

        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

        void Hit()
            {
                if(target == null) return;

                //GetComponent<Animator>().ResetTrigger("stopAttack");
                //TriggerAttack();
                //GetComponent<Animator>().SetTrigger("attack");


                target.TakeDamage(weaponDamage);
            }
            
       
    }

}