using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	// Use this for initialization
	void OnEnable()
	{
		GetComponent<Text>().text = NameGenerator.GenerateChat(8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
