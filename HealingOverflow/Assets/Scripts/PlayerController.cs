﻿using System.Collections;
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

    private Rigidbody2D mRigidy;
    private Animator mAnim;

    //List<Animation>
    void Start()
    {
        mRigidy = gameObject.GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
    }

    private void Update()
	{
        Vector3 dir = (destination - transform.position);
        if (dir.magnitude > 0.1)
        {
            mRigidy.velocity = dir.normalized * moveSpeed;
        }
        else
        {
            mRigidy.velocity = Vector3.zero;
        }
        Debug.Log("Vetor:" + mRigidy.velocity + " Normalizado:" + mRigidy.velocity.normalized);
        
        mAnim.SetFloat("Horizontal",mRigidy.velocity.normalized.x);
        mAnim.SetFloat("Vertical",mRigidy.velocity.normalized.y);
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
