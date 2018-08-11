using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentBar : MonoBehaviour
{
	[SerializeField] private RectTransform bar;
	public float Value
	{ 
		get
		{
			return bar.anchorMax.x;
		}
		set
		{
			bar.anchorMax = new Vector2(value, bar.anchorMax.y);
		}
	}
}
