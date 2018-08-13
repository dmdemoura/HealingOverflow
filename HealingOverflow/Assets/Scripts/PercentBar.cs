using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentBar : MonoBehaviour
{
	[SerializeField] private RectTransform bar;
	[SerializeField] private RectTransform extraBar; //For when value > 100
	public float Value
	{ 
		get
		{
			return bar.anchorMax.x + extraBar.anchorMax.x;
		}
		set
		{
			float barValue = 0f;
			float extraValue = 0f;
			if (value <= 1f)
				barValue = value;
			else
			{
				barValue = 1f;
				extraValue = value - 1f;
			}
			bar.anchorMax = new Vector2(barValue, bar.anchorMax.y);
			if (extraBar)
				extraBar.anchorMax = new Vector2(extraValue, extraBar.anchorMax.y);
		}
	}
}
