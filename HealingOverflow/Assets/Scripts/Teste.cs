using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = -transform.position;
       
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
