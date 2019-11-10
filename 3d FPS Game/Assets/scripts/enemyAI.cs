using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    float distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
          

        }
        OnDrawGizmosSelected();
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * turnSpeed);
    }

    private void EngageTarget()
    {
        
      if(distanceToTarget >= navMeshAgent.stoppingDistance )
        {
            ChaseTarget();
            
        }
      
        if (distanceToTarget<= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
            FaceTarget();
		}
		
        

       
    }

    private void AttackTarget()
    {
        Debug.Log(name + "has seeked and is destroying" + target.name);
        animator.SetBool("attack", true);
    }

    private void ChaseTarget()
    {
         navMeshAgent.SetDestination(target.position);
         animator.SetTrigger("move");
        animator.SetBool("attack", false);
    }

        void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
