using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWhileWalking : MonoBehaviour {
	Rigidbody2D mRigid;
	[SerializeField] float jumpFreq;
	[SerializeField] float jumpHight;
	// Use this for initialization
	void Start () {
		mRigid = gameObject.GetComponentInParent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(mRigid.velocity.magnitude > 0.1f){
			transform.localPosition = Vector3.up * Mathf.Sin(Time.time*jumpFreq) * jumpHight;
		}
	}
}
