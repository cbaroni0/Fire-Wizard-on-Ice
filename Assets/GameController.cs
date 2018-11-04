using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public float speed;

	private Rigidbody2D rb2d;
	private SpriteRenderer spriteRenderer;

	public GameObject shotLeft;
	public GameObject shotRight;
	public GameObject shotUp;
	public GameObject shotDown;
	public GameObject shotUpLeft;
	public GameObject shotUpRight;
	public GameObject shotDownLeft;
	public GameObject shotDownRight;
	public Sprite diagonalRU;
	public Sprite diagonalLU;
	public Sprite down;
	public Sprite idle;
	public Sprite left;
	public Sprite right;
	public Sprite up;
	bool upLit;
	bool downLit;
	bool rightLit;
	bool leftLit;
	int fireAt; //1-8 starting at top, going clockwise, 0 is no fire

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		fireAt = 0;
		upLit = false;
		downLit = false;
		leftLit = false;
		rightLit = false;
		shotUp.SetActive (false);
		shotDown.SetActive (false);
		shotLeft.SetActive (false);
		shotRight.SetActive (false);
		shotUpLeft.SetActive (false);
		shotUpRight.SetActive (false);
		shotDownLeft.SetActive (false);
		shotDownRight.SetActive (false); //look at how tasty this initialization is
	}

	void Update ()
	{
		if (Input.GetKeyDown("up"))
		{
			if (!shotUp.activeSelf)
			{
				downLit = true;
			}
		}
		if (Input.GetKeyDown("down"))
		{
			if (!shotDown.activeSelf)
			{
				upLit = true;
			}
		}
		if (Input.GetKeyDown("right"))
		{
			if (!shotRight.activeSelf)
			{
				leftLit = true;
			}
		}
		if (Input.GetKeyDown("left"))
		{
			if (!shotLeft.activeSelf)
			{
				rightLit = true;
			}
		}
		//end keydown
		if (Input.GetKeyUp("up"))
		{
			downLit = false;
			if (Input.GetKey ("down"))
			{
				upLit = true;
			}

		}

		if (Input.GetKeyUp("down"))
		{
			upLit = false;
			if (Input.GetKey ("up"))
			{
				downLit = true;
			}
		}

		if (Input.GetKeyUp("right"))
		{
			leftLit = false;
			if (Input.GetKey ("left"))
			{
				rightLit = true;
			}
		}

		if (Input.GetKeyUp("left"))
		{
			rightLit = false;
			if (Input.GetKey ("right"))
			{
				leftLit = true;
			}
		}
		//end key up
		CheckLit ();
	}
		
	void CheckLit()
	{
		if (upLit) {
			if (rightLit) {
				SetFire (2);
			} else if (leftLit) {
				SetFire (8);
			} else {
				SetFire(1);
			}
		} else if (downLit) {
			if (rightLit) {
				SetFire(4);
			} else if (leftLit) {
				SetFire(6);
			} else {
				SetFire(5);
			}
		} else if (leftLit) {
			SetFire(7);
		} else if (rightLit) {
			SetFire(3);
		} else {
			SetFire(0);
		}
	}

	void SetFire(int newFire)
	{
		if (fireAt != newFire) {
			Snuff ();
			fireAt = newFire;

			switch (fireAt) {
			case 0:
				spriteRenderer.sprite = idle;
				break;
			case 1:
				shotUp.SetActive (true);
				spriteRenderer.sprite = up;
				break;
			case 2:
				shotUpRight.SetActive (true);
				spriteRenderer.sprite = diagonalRU;
				break;
			case 3:
				shotRight.SetActive (true);
				spriteRenderer.sprite = right;
				break;
			case 4:
				shotDownRight.SetActive (true);
				spriteRenderer.sprite = diagonalLU;
				break;
			case 5:
				shotDown.SetActive (true);
				spriteRenderer.sprite = down;
				break;
			case 6:
				shotDownLeft.SetActive (true);
				spriteRenderer.sprite = diagonalRU;
				break;
			case 7:
				shotLeft.SetActive (true);
				spriteRenderer.sprite = left;
				break;
			case 8:
				shotUpLeft.SetActive (true);
				spriteRenderer.sprite = diagonalLU;
				break;
			default:
				break;
			}
		}
	}

	void Snuff()
	{
		switch (fireAt) {
		case 1:
			shotUp.SetActive (false);
			break;
		case 2:
			shotUpRight.SetActive (false);
			break;
		case 3:
			shotRight.SetActive (false);
			break;
		case 4:
			shotDownRight.SetActive (false);
			break;
		case 5:
			shotDown.SetActive (false);
			break;
		case 6:
			shotDownLeft.SetActive (false);
			break;
		case 7:
			shotLeft.SetActive (false);
			break;
		case 8:
			shotUpLeft.SetActive (false);
			break;
		default:
			break;
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}
}
