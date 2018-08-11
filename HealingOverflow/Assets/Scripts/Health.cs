using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public bool PlayerisDead;
    public bool EnemyisDead;

    IANoobsandOrcs ia;

    private void Start()
    {
        ia = GetComponent<IANoobsandOrcs>();
        currentHealth = startingHealth;
    }

    public void Damage(int amount)
    {
        if(ia.attackArea)
        {
            ia._target.GetComponent<Health>().currentHealth -= amount;
        }
        else if(ia.playerattack)
        {
            currentHealth -= amount;
        }
        

        if (this.CompareTag("Player"))
        { 
            if (ia._target.GetComponent<Health>().currentHealth <= 0 && !EnemyisDead)
            {
               EnemyisDead = true;
                GameManager.DestroyEntity(ia._target);
                
            }
           
        }
        else if(this.CompareTag("Enemy"))
        {
            if (ia._target.GetComponent<Health>().currentHealth <= 0 && !PlayerisDead)
            {
                PlayerisDead = true;
                Debug.Log("Game Over");
            }
           
        }

    }
    
    
}
