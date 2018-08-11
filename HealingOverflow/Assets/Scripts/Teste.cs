using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.SpawnAt("Player", new Vector3(1f, 1f, 1f));
        GameManager.SpawnAt("Player", new Vector3(2f, 1f, 1f));
        GameManager.SpawnAt("Finish", new Vector3(1f, 2f, 1f));
        GameManager.SpawnAt("Player", new Vector3(2f, 2f, 1f));

       
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Objeto a ser deletado: " + GameManager.FindNearAt("Player", new Vector3(0.5f,1f,0f)).name);
            GameManager.DestroyEntity(GameManager.FindNearAt("Player", new Vector3(0.5f, 1f, 0f)));
        }
	}
}
