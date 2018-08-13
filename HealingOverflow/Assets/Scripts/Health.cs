using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField] private PercentBar percentbar;
    [SerializeField] public int startingHealth = 100;
    public int currentHealth;
    public int duplicationHealth = 200;
    private bool isDead;
    public float HealthPercentage
    {
        get
        {
            return (float) currentHealth / (float) startingHealth;
        }
    }

    private void Start()
    {
        currentHealth = startingHealth;
        percentbar.Value = HealthPercentage;
    }
    private void Update()
    {
        if (currentHealth >= duplicationHealth)
        {
            currentHealth = startingHealth;
            percentbar.Value = HealthPercentage;

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

        percentbar.Value = HealthPercentage;
    }

    public void Heal(int healingPower)
    {
        currentHealth += healingPower;

       percentbar.Value = HealthPercentage;
    }

}
