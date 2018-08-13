using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : MonoBehaviour 
{
	[Tooltip("For correcting for the sprite not filling the entire object")]
	[SerializeField] private float sizeMultiplier = 0.781f;
	private bool activated = false;
	private float startTime;
	private float duration;
	private int healingPower;
	public void Activate(float duration, int healingPower)
	{
		startTime = Time.realtimeSinceStartup;
		this.duration = duration;
		this.healingPower = healingPower;
		activated = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.lossyScale.x / 2f * sizeMultiplier);

        foreach (Collider2D collider in colliders)
        {
            Health health = collider.gameObject.GetComponent<Health>();
            if (health && healingPower > 0)
            {
                health.Heal(healingPower);
            }
        }
    }
	private void Update() 
	{
		if (activated)
		{
			if (Time.realtimeSinceStartup - startTime >= duration)
			{
				Destroy(gameObject);
			}
		}
	}
}
 