using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour {

	private void OnEnable()
	{
		GetComponent<Text>().text = NameGenerator.GenerateUsername();
	}
}
