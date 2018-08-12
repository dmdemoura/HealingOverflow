using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    bool PlayerisDead;
    bool EnemyisDead;

    public Slider healthSlider;

    private void Awake()
    {
        currentHealth = startingHealth;
        healthSlider.value = startingHealth;
    }
    private void Update()
    {
        if (currentHealth > 100)
        {

            currentHealth = 100;
            Vector3 PlayerPos = this.transform.position + Vector3.right;
            GameManager.SpawnAt(gameObject.tag, PlayerPos);
            
        }

        if(this.CompareTag("Player") && currentHealth <= 0 && !PlayerisDead)
        {
            PlayerisDead = true;
            Debug.Log("Game Over");
        }
        else if(this.CompareTag("Enemy") && currentHealth <= 0 && !EnemyisDead)
        {
            EnemyisDead = true;
            GameManager.DestroyEntity(this.gameObject);
        }
    }


    public void Damage(int amount)
    {
        currentHealth -= amount;

        healthSlider.value = currentHealth;
    }

    public void Heal(int healingPower)
    {
        currentHealth += healingPower;

        healthSlider.value = currentHealth;
    }

}
