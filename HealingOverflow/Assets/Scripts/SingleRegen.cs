using UnityEngine;

public class SingleRegen : SingleTargetMagic
{
    [SerializeField] private int healingPower;
    [SerializeField] private float healingPulseRate;
    [SerializeField] private float healingDuration;
    [SerializeField] private GameObject regenAnimationPrefab;
    protected override void OnTargetFound(GameObject target)
    {
        target.AddComponent<RegenEffect>().Activate(healingPower, healingPulseRate, healingDuration, regenAnimationPrefab);
        
    }
}