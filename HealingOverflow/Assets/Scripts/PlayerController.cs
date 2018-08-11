using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private int moveMouseButton = 0;
	[SerializeField] private float moveSpeed = 0.1f;
	private Vector3 destination;
	private float moveProgress;
	public bool MovementLock { get; set; }
	private void Update()
	{
		if (moveProgress != 1.0f)
		{
			moveProgress += moveSpeed;
			transform.position = Vector3.Lerp(transform.position, destination, moveProgress);
		}
	}
	public void OnWorldCLick()
	{
		if (!MovementLock)
		{
			Vector3 screenPos = Input.mousePosition;
			Vector2 worldpos  = mainCamera.ScreenToWorldPoint(screenPos);

			moveProgress = 0.0f;
			destination = worldpos;
		}
	}
}
