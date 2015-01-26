using UnityEngine;
using System.Collections;

public class TestXboxController : MonoBehaviour {

	public float speed = 10;
	private float x = 0f;
	private float y = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("LeftJoystickX");
		y = Input.GetAxis ("LeftJoystickY");



		
		//update transform
		transform.Translate (new Vector3 (x, y, 0f) * speed * Time.deltaTime); 


	}
}
