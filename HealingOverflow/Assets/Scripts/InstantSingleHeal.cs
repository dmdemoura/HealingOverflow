using UnityEngine;

public class InstantSingleHeal : SingleTargetMagic
{
    [SerializeField] private int healingPower;
    protected override void OnTargetFound(GameObject target)
    {
        target.GetComponent<Health>().Heal(healingPower);
    }
}