using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpin : MonoBehaviour {
    public float speed = 10f;
	public void Spin()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
