using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField]  float health = 100f;
        bool isDead = false;

        public bool ISDead(){
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage,0);

            if(health == 0)
            {
                Die();
            }
            print(health);

        }

        private void Die()
        {
            if(isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

}