using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damageAmount = 45f;
    [SerializeField] ParticleSystem shoot;
    [SerializeField] GameObject explosion;
    [SerializeField] int bullet = 30;
    [SerializeField] int þarjör = 10;
    void Update()
    {
        if(bullet > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            text.text = bullet.ToString() + "/" + þarjör.ToString();
        }
        if(þarjör > 0)
        {
            if (Input.GetKeyDown(KeyCode.R)) // "R" tuþuna basýldýðýnda çalýþýr
            {
                Reload();
            }
        }
        


    }

    void Shoot()
    {
        ShootingEffect();
        Raycasting();
        bullet--;
    }

    private void Raycasting()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            HitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.GetDamage(damageAmount);
        }
        else
        {
            return;
        }
    }

    private void HitEffect(RaycastHit hit)
    {
        GameObject hitVisual = Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitVisual,1);
    }

    private void ShootingEffect()
    {
        shoot.Play();
    }

    void Reload()
    {
        bullet = 30; // Mermiyi baþlangýç deðerine döndür
        Debug.Log("Reloaded!");
        þarjör--;
    }

}
