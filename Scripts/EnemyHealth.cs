using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Image image;
    
    [SerializeField] float hitPoints = 100f;
    [SerializeField] NavMeshAgent move;
    
    public void GetDamage(float damage) 
    {
       
        hitPoints -= damage;
        
        if(hitPoints <= 0)
        {
            GetComponent<Animator>().SetBool("Death", true);
            move.isStopped = true;
            Invoke("Death", 3f);
        }
    }
    void Death() 
    {
        Destroy(gameObject);
    }

}
