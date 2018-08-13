using UnityEngine;

public class RegenEffect : MonoBehaviour
{
    private GameObject regenAnimation;
    private bool activated = false;
    private int healingPower;
    private Health health;

    private void HealPulse()
    {
        health.Heal(healingPower);
    }
    private void SelfDestroy()
    {
        Destroy(regenAnimation);
        Destroy(this);
    }
    public void Activate(int healingPower, float healingPulseRate, float healingDuration, GameObject regenAnimationPrefab)
    {
        this.healingPower = healingPower;
        health = GetComponent<Health>();
        activated = true;
        InvokeRepeating("HealPulse", 0.0f, healingPulseRate);
        Invoke("SelfDestroy", healingDuration);
        regenAnimation = Instantiate(regenAnimationPrefab, transform);
    }
}