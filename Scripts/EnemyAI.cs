using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] PlayerHealth playerhealth;
    [SerializeField] Transform target;
    [SerializeField] float chasingRadious = 6f;
     float damage = 00000000000000000000000000000000000000000000.1f;



    NavMeshAgent navMeshAgent;
    float targetDistance = Mathf.Infinity;
    bool isProved = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerhealth = FindObjectOfType<PlayerHealth>();
        

    }

    // Update is called once per frame
    void Update()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);

        if (isProved)
        {
            DelayWithTarget();
        }

        else if (targetDistance <= chasingRadious )
        {
            isProved = true;
        }

    }

    private void DelayWithTarget()
    {
        if (targetDistance >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (targetDistance <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
            playerdamage();
            
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        
        
        //Debug.Log(name + "is destroying" + target.name);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
        if  (targetDistance > chasingRadious ) 
        {
            isProved = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRadious);
    }
    void playerdamage()
    {
        playerhealth.GetDamage(damage);
    }
}
