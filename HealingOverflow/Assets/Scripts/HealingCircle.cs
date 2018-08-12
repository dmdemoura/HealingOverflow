using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : MonoBehaviour 
{
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
	}
	private void Update() 
	{
		if (activated)
		{
			if (Time.realtimeSinceStartup - startTime < duration)
			{
				Collider2D[] colliders =Physics2D.OverlapCircleAll(transform.position, 30.0f);
			
				foreach (Collider2D collider in colliders)
				{
					Health health = collider.gameObject.GetComponent<Health>();
					if (health)
					{
						health.Damage(-healingPower);
					}
				}
				healingPower = 0;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
 