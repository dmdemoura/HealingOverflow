﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.N))
		{
			Debug.Log("Yay");
			Debug.Log(NameGenerator.GenerateUsername());
		}
	}
}