using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int startingHealth = 100;
  
    public int PlayerHealth;
    public int EnemyHealth;

    bool damaged;
    bool isdead;

    private void Awake()
    {
      
        PlayerHealth = startingHealth;
        EnemyHealth = startingHealth;
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

        if(this.CompareTag("Player"))
        {
           EnemyHealth -= amount;

            if (EnemyHealth <= 0 && !isdead)
            {
                Death();
            }
        }
        else if(this.CompareTag("Enemy"))
        {
            PlayerHealth -= amount;

            if (PlayerHealth <= 0 && !isdead)
            {
                Death();
            }
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
            Destroy(this.gameObject);
            Debug.Log("Enemy is dead");
        }
    }
}
