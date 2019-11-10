using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using System;
using RPG.Combat;

namespace RPG.Control
{
    public class playerController : MonoBehaviour
    {
        private void Update()
        {
            if (InteractWithCombat()) return; 
            if(InteractWithMovement()) return;

        }
        

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
               
                Combattarget target = hit.transform.GetComponent<Combattarget>();
                if(target == null) continue;

             
                //if(!GetComponent<Fighter>().CanAttack(target.gameObject)) continue;
                if (Input.GetMouseButtonDown(0))
                {
                   
                    GetComponent<Fighter>().Attack(target.gameObject);
                  
                }
                return true;

            }return false;
        }

        private bool InteractWithMovement()
        {
            Ray ray = GetMouseRay();
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                    
                }
                return true;

            }
            return false;
        }

      

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}