using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnorbAI : MonoBehaviour {
	public float speed;

	void Start (){
	}

	void Update() {
		transform.position = Vector3.MoveTowards (transform.position, 
			GameObject.Find ("wizard").transform.position,
			speed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Fire") {
			Destroy (gameObject);
		}
	}

}
