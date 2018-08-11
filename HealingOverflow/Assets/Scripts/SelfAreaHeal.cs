using UnityEngine;
public class SelfAreaHeal : Magic
{
	[SerializeField] private GameObject healingCirclePrefab;
    [SerializeField] private float healingCircleDuration;
    [SerializeField] private float healingCirclePower;
    protected override void OnCast()
    {
        HealingCircle healingCircle = Instantiate(healingCirclePrefab, transform.position, transform.rotation).GetComponent<HealingCircle>();
        healingCircle.Activate(healingCircleDuration, healingCirclePower);
        StartCooldown();
    }
}