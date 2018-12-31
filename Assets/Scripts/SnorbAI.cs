using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnorbAI : MonoBehaviour {
	public float speed;
    public int score;
    private float accel;
    private GameObject panelAccess;

	void Start ()
    {
        score = 0;
        accel = (float)0.005;
        panelAccess = GameObject.Find("GameOverMenu");
        panelAccess.SetActive(false);
    }

	void Update() {
		transform.position = Vector3.MoveTowards (transform.position, 
			GameObject.Find ("wizard").transform.position,
			speed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Fire")
        {
            score++;
            int rng = (int)(Random.value * (float)8.0);
            this.speed += accel; //continues to get faster every round
            switch(rng)
            { 
                case 0: 
                    this.transform.position = new Vector3((float)2.8, (float)5.1, -1);
                    break;
                case 1:
                    this.transform.position = new Vector3((float)6.8, (float)2.1, -1);
                    break;
                case 2:
                    this.transform.position = new Vector3((float)-2.8, (float)5.1, -1);
                    break;
                case 3:
                    this.transform.position = new Vector3((float)-6.8, (float)2.1, -1);
                    break;
                case 4:
                    this.transform.position = new Vector3((float)2.8, (float)-5.1, -1);
                    break;
                case 5:
                    this.transform.position = new Vector3((float)6.8, (float)-2.1, -1);
                    break;
                case 6:
                    this.transform.position = new Vector3((float)-2.8, (float)-5.1, -1);
                    break;
                case 7:
                    this.transform.position = new Vector3((float)-6.8, (float)-2.1, -1);
                    break;
                case 8: //either 8 or zero isn't possible so they're the same
                    this.transform.position = new Vector3((float)2.8, (float)5.1, -1);
                    break;
                default: //error will continue to spawn in start location
                    this.transform.position = new Vector3((float)2.8, (float)5.1, -1);
                    break;
            }
        }
        else if(other.tag == "Player")
        {
            speed = 0;
            accel = 0;
            this.gameObject.SetActive(false);
            panelAccess.SetActive(true);
        }
	}

}
