using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth playerhealth;
   
    [SerializeField] float damage = 10f;

    void Start()
    {
       
        playerhealth = FindObjectOfType<PlayerHealth>();
    }

    public void HitEvent()
    {
        if (playerhealth == null) return;
        playerhealth.GetDamage(damage);
       // Debug.Log("Enemy hits the player");
    }

}
