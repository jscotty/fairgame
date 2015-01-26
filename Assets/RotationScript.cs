using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
	
	private float rot = 0f;
	public float rotSpeed = 500f;

	void Update () {
		
		rot = Input.GetAxis ("RightJoystickX");
		
		transform.Rotate(new Vector3(0f,0f,rot) * -1 * rotSpeed * Time.deltaTime);
	}
}
