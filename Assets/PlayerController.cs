using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	private float x = 0f;
	private float y = 0f;

	private float maxWidth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (name == "Player1") {
			x = Input.GetAxis ("LeftJoystickX");
			y = Input.GetAxis ("LeftJoystickY");

			maxWidth = 4.5f;
			if (transform.position.x >= maxWidth) {
				transform.position = new Vector3(maxWidth,transform.position.y,transform.position.z);		
			} else if (transform.position.x <= -.5f) {
				transform.position = new Vector3(-.5f,transform.position.y,transform.position.z);		
			}

			if (Input.GetButtonDown ("A")) {
				print ("shoot");	
			}

		}else if (name == "Player2") {
			x = Input.GetAxis ("LeftJoystickX2");
			y = Input.GetAxis ("LeftJoystickY2");
			
			maxWidth = -5f;
			if (transform.position.x <= maxWidth) {
				transform.position = new Vector3(maxWidth,transform.position.y,transform.position.z);		
			} else if (transform.position.x >= 0f) {
				transform.position = new Vector3(0f,transform.position.y,transform.position.z);		
			}

			print(transform.position.x);
		}
		//update transform
		transform.Translate (new Vector3 (x, y, 0f) * speed * Time.deltaTime); 


		
		
	}
}