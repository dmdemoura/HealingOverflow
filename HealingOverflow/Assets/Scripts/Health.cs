using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public bool isDead;

    public PercentBar percentbar;

    private void Start()
    {
        currentHealth = startingHealth;
        percentbar.Value = startingHealth;
    }
    private void Update()
    {
        if (currentHealth >= 200)
        {
            currentHealth = 100;
            percentbar.Value = currentHealth;

            Vector3 PlayerPos = this.transform.position + Vector3.right;
            GameManager.SpawnAt(gameObject.tag, PlayerPos); 
        }

        if(currentHealth <= 0 && !isDead)
        {
            GameManager.DestroyEntity(this.gameObject);
        }
    
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;

        percentbar.Value = currentHealth;
    }

    public void Heal(int healingPower)
    {
        currentHealth += healingPower;

       percentbar.Value = currentHealth;
    }

}
