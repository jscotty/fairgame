using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	private float x = 0f;
	private float y = 0f;

	public float maxWidth = 5.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("LeftJoystickX");
		y = Input.GetAxis ("LeftJoystickY");
		
		//update transform
		transform.Translate (new Vector3 (x, y, 0f) * speed * Time.deltaTime); 

		if (transform.position.x >= maxWidth) {
			transform.position = new Vector3(maxWidth,transform.position.y,transform.position.z);		
		}

		if (Input.GetButtonDown ("A")) {
			print ("shoot");	
		}
		
		
	}
}