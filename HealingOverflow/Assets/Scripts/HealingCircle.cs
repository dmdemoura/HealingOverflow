using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : MonoBehaviour 
{
	private bool activated = false;
	private float startTime;
	private float duration;
	private float healingPower;
	public void Activate(float duration, float healingPower)
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
				
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
