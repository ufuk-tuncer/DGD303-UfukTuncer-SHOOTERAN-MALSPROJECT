using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deadtext;
    [SerializeField] Image heathbar;
    [SerializeField] float health = 100;
    [SerializeField] private float hitPoints = 100f;

    public void GetDamage(float damage)
    {
        health -= damage;
        hitPoints -= damage;

        if (health <= 0)
        {
            
            deadtext.gameObject.SetActive(true);
            RestartLevel();
        }
        
    }
   
    void Update()
    {
        heathbar.fillAmount = health / 100;
    }
    void Start()
    {
        deadtext.gameObject.SetActive(false);
    }


    public void RestartLevel()
    {
        // Sonraki seviyeye geçiş yapar
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex );
    }
}
