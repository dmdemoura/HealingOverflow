using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
  
    bool damaged;
    bool isdead;

    private void Awake()
    {
        currentHealth = startingHealth;
        
    }

    private void Update()
    {
        if(damaged)
        {
            Debug.Log("damaged");
        }
    }

    public void Damage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if(currentHealth <= 0 && !isdead)
        {
            Death();
        }
    }

    void Death()
    {
        isdead = true;

        if(this.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
        else if(this.CompareTag("Enemy"))
        {
            Debug.Log("Enemy is dead");
        }
    }
}
