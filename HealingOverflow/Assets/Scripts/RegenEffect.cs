using UnityEngine;

public class RegenEffect : MonoBehaviour
{
    private bool activated = false;
    private int healingPower;
    private float healingDuration;
    private Health health;
    private void HealPulse()
    {
        health.Heal(healingPower);
    }
    private void SelfDestroy()
    {
        Destroy(this);
    }
    public void Activate(int healingPower, float healingPulseRate, float healingDuration)
    {
        this.healingPower = healingPower;
        this.healingDuration = healingDuration;
        health = GetComponent<Health>();
        activated = true;
        InvokeRepeating("HealPulse", 0.0f, healingPulseRate);
        Invoke("SelfDestroy", healingDuration);
    }
}